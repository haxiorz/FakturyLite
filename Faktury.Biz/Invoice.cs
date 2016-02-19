using System.Collections.Generic;

namespace Faktury.Biz
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OwnerId { get; set; }
        public string Date { get; set; }
        public string NumberOfInvoice { get; set; }
        public Client Client { get; set; }
        public Owner Owner { get; set; }
        public List<Product> products { get; set; }
        

        public Invoice(string date, string invoicenumber, Client client, Owner owner, List<Product> products)
        {
            this.Date = date;
            this.Client = client;
            this.Owner = owner;
            this.products = products;
            this.NumberOfInvoice = invoicenumber;
        }
    }
}
