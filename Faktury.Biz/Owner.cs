using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Biz
{
    public class Owner : Company
    {
        public Owner(string name, string address, string nip) : base(name, address, nip)
        {

        }

        public Owner()
        {

        }
    }
}
