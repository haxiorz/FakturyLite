using System.Data.Entity;
using Faktury.Biz;

namespace Faktury.Biz
{
    public class FakturyContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
