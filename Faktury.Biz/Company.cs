using System.Collections.Generic;

namespace Faktury.Biz
{
    public abstract class Company
    {
        public int Id { get; set; }
        public List<Invoice> Invoice { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string NIP { get; set; }


        public Company(string name, string address, string city, string postcode, string nip)
        {
            this.Name = name;
            this.Address = address;
            this.NIP = nip;
            this.City = city;
            this.PostCode = postcode;
        }

        public Company()
        {

        }
    }
}
