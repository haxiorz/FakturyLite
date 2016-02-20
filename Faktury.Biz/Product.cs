using System;

namespace Faktury.Biz
{
    public class Product
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public decimal VAT { get; set; }
        public decimal Quantity { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal BruttoPrice { get; set; }
        public decimal TotalNettoPrice
        {
            get { return NettoPrice * Quantity; }
        }
       
        public decimal TotalBruttoPrice
        {
            get { return Math.Round((NettoPrice + NettoPrice * VAT/100) * Quantity, 2); }
        }

        public decimal VATValue
        {
            get { return Math.Round(VAT / 100 * TotalNettoPrice, 2); }
        }

        private void CalculateNettoToBrutto()
        {
           BruttoPrice = Math.Round(NettoPrice + (NettoPrice * VAT / 100), 2);
        }

        private void CalculateBruttoToNetto()
        {
            NettoPrice = Math.Round(100 * BruttoPrice / (100 + VAT));
        }
        
        public Product(int id, string name, decimal vat, decimal quantity, decimal price, bool netto)
        {
            this.Id = id;
            this.Name = name;
            this.VAT = vat;
            this.Quantity = quantity;
            if (netto)
            {
                this.NettoPrice = price;
                CalculateNettoToBrutto();
            }
            else
            {
                this.BruttoPrice = price;
                CalculateBruttoToNetto();
            }
        }
    }
}
