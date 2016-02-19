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
        public decimal TotalNettoPrice
        {
            get { return NettoPrice * Quantity; }
        }
        public decimal BruttoPrice
        {
            get { return Math.Round(NettoPrice + (NettoPrice * VAT/100), 2); }
        }
        public decimal TotalBruttoPrice
        {
            get { return Math.Round((NettoPrice + NettoPrice * VAT/100) * Quantity, 2); }
        }

        public decimal VATValue
        {
            get { return Math.Round(VAT / 100 * TotalNettoPrice, 2); }
        }
        
        public Product(int id, string name, decimal vat, decimal quantity, decimal nettoprice)
        {
            this.Id = id;
            this.Name = name;
            this.VAT = vat;
            this.Quantity = quantity;
            this.NettoPrice = nettoprice;
        }

    }
}
