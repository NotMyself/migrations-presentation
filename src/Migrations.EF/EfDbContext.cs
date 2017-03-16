using System.Data.Entity;

namespace Migrations.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(): base("DefaultConnection")
        { }
    }
}
