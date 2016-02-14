using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Biz
{
    public class Client : Company
    {
        public Client(string name, string address, string city, string postcode, string nip) : base(name, address, city, postcode, nip)
        {

        }

        public Client()
        {

        }
    }
}
