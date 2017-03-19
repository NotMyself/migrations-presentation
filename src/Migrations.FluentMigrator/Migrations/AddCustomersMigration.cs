using FluentMigrator;

namespace Migrations.FluentMigrator.Migrations
{
    //[Migration(4)]
    public class AddCustomersMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Customers")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FirstName").AsAnsiString().NotNullable()
                .WithColumn("LastName").AsAnsiString().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Updated").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Customers");
        }
    }
}
