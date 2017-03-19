using Microsoft.EntityFrameworkCore;
using Migrations.Model;

namespace Migrations.EF.Core
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        { }

        //public DbSet<Transaction> Transactions { get; set; }

        //public DbSet<Account> Accounts { get; set; }

        //public DbSet<Customer> Customers { get; set; }
    }
}
