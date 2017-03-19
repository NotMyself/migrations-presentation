using System.Data.Entity;

namespace Migrations.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(): base("DefaultConnection")
        { }

        //public DbSet<Transaction> Transactions { get; set; }

        //public DbSet<Account> Accounts { get; set; }

        //public DbSet<Customer> Customers { get; set; }
    }
}
