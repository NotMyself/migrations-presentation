# FluentMigrator

FluentMigrator is a popular OSS framework that is not dependant on any specific data access technology. It is capible of running against a whole [host of relation database platforms](https://github.com/fluentmigrator/fluentmigrator/wiki/Supported-Databases). Migrations are code based and schema is defined using a [fluent interface](https://github.com/fluentmigrator/fluentmigrator/wiki/Fluent-Interface). It supports both targeted upgrading and downgrading. Migrations can be executed from the command line or [several other task based libraries](https://github.com/fluentmigrator/fluentmigrator/wiki/Migration-Runners).

## About

- Maintained By: [Sean Chambers](https://github.com/schambers) & [Others](https://github.com/fluentmigrator/fluentmigrator/graphs/contributors)
- [NuGet](https://www.nuget.org/packages/FluentMigrator/)
- [Source](https://github.com/fluentmigrator/fluentmigrator)
- [Documentation](https://github.com/fluentmigrator/fluentmigrator/wiki)

### Installation

```powershell
Install-Package FluentMigrator
```

### Example Migration

```csharp
using FluentMigrator;

namespace Migrations.FluentMigrator.Migrations
{
    [Migration(1)]
    public class InitMigration : Migration
    {
        public override void Up()
        {
            
        }

        public override void Down()
        {
            
        }
    }
}
```

### CLI Based Execution

```powershell
.\packages\FluentMigrator.1.6.2\tools\Migrate.exe `
 /connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FluentMigrator;Integrated Security=True;" `
 /provider SqlServer2014 `
 /assembly src\Migrations.FluentMigrator\bin\Debug\Migrations.FluentMigrator.dll `
 /verbose true
```

