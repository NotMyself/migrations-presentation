using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Migrations.EF.Core
{
    public class EfDbContextFactory : IDbContextFactory<EfDbContext>
    {
        IConfigurationRoot Configuration;

        public EfDbContextFactory()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public EfDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<EfDbContext>();

            builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new EfDbContext(builder.Options);
        }
    }
}
