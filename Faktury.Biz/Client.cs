
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
