using FluentMigrator;

namespace Migrations.FluentMigrator.Migrations
{
    //[Migration(3)]
    public class AddAccountsMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Accounts")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Updated").AsDateTime().NotNullable();

            Alter.Table("Transactions")
                .AddColumn("AccountId").AsInt32().NotNullable();

            Create.Index("IX_Transactions_AccountId")
                .OnTable("Transactions").OnColumn("AccountId")
                .Ascending();

            Create.ForeignKey("FK_Transactions_Account")
                .FromTable("Transactions").ForeignColumn("AccountId")
                .ToTable("Accounts").PrimaryColumn("Id");
                
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Transactions_Account")
                .OnTable("Transactions");

            Delete.Index("IX_Transactions_AccountId")
                .OnTable("Transactions");

            Delete.Table("Accounts");
        }
    }
}
