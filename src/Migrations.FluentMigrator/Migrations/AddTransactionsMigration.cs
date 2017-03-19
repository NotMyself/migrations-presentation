using FluentMigrator;

namespace Migrations.FluentMigrator.Migrations
{
    //[Migration(2)]
    public class AddTransactionsMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Transactions")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Amount").AsDecimal().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Updated").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Transactions");
        }
    }
}
