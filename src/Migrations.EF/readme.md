# Entity Framework Migrations

Entity Framework is the current data access technology baked into .net. It is dependant on Microsoft Sql Server but supports multiple versions and flavors. Migrations are code based and schema is defined using a fluent interface. It supports both targeted upgrading and downgrading. Migrations can be executed from the Package Manager Console or when an applicaiton starts. CLI execution is not supported.


## About

- Maintained By: [Microsoft](https://github.com/aspnet/EntityFramework6/graphs/contributors)
- [NuGet](https://www.nuget.org/packages/EntityFramework/)
- [Source](https://github.com/aspnet/EntityFramework6)
- [Documentation](https://msdn.microsoft.com/en-us/library/ee712907(v=vs.113).aspx)

### Installation

```powershell
Install-Package EntityFramework
```

### Example Migration

```csharp
namespace Migrations.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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

### Package Manager Console Based Execution

All Entity Framework migration commands must be excuted from inside Visual Studio's Package Manager Console. This makes it difficult for CI systems to interact with the migrations to deploy them to an environment or generate data change scripts at build time.

#### Applying Migrations to Database

```powershell
Update-Database
```

Will connect to the database and apply any migrations that have not already been applied.

```powershell
Update-Database -Verbose
```

Same as previous example but will print all sql statements to the console.

#### Creating and Destroying Migrations

```powershell
Add-Migration MeaningfullName
```

Will look at the current state of our model and generate migration for any changes from the previous migration.

```powershell
Remove-Migration MeaningfullName
```

Will attempt to remove the migration from the project.

### Generating Change Scripts

```powershell
Update-Database -Script -SourceMigration: $InitialDatabase
```

Will generate an idempotent sql script containging all the migrations. This script can be run on an empty database or an existing database, only the missing migrations will be applied.

```powershell
Update-Database -Script -TargetMigration $InitialDatabase
```

Will connect to the currently configured database and generate destructive scripts to drop all migrations applied back to an empty database.