using Microsoft.EntityFrameworkCore;

namespace Migrations.EF.Core
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        { }
    }
}
