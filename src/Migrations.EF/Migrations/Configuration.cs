namespace Migrations.EF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
