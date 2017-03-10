using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Migrations.EF.Core
{
    public partial class AccountingContext : DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options) : base(options)
        {

        }
    }

    public class TestDbContextFactory : IDbContextFactory<AccountingContext>
    {
        public IConfigurationRoot Configuration { get; private set; }

        public TestDbContextFactory()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        public AccountingContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptions<AccountingContext>();

            builder.UseSqlServer(Configuration.GetConnectionString("Accounting"));

            return new AccountingContext(builder.Options);
        }
    }
}