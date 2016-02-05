using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Biz
{
    public abstract class Company
    {
        public int Id { get; set; }
        public List<Invoice> Invoice { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NIP { get; set; }


        public Company(string name, string address, string nip)
        {
            this.Name = name;
            this.Address = address;
            this.NIP = nip;
        }

        public Company()
        {

        }
    }
}
