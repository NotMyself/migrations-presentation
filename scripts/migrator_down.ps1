.\packages\FluentMigrator.1.6.2\tools\Migrate.exe `
 /connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FluentMigrator;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" `
 /provider SqlServer2014 `
 /assembly src\Migrations.FluentMigrator\bin\Debug\Migrations.FluentMigrator.dll `
 /verbose true `
 --task migrate:down