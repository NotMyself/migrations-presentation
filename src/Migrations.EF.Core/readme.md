# Entity Framework Core Migrations

Entity Framework Core is the new data access technology baked into .net core. It is cross platform and supports multiple relational databases. It supports both targeted upgrading and downgrading. Migrations can be executed from the PMC or via the dotnet CLI. The dotnet CLI makes it highly scriptable and CI friendly.

## About

- Maintained By: [Microsoft](https://github.com/aspnet/EntityFramework/graphs/contributors) & a huge number of OSS contributors
- [NuGet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
- [Source](https://github.com/aspnet/EntityFramework)
- [Documentation](https://docs.microsoft.com/en-us/ef/)

### Installation

```powershell
Install-Package EntityFramework
```

This is just a base class library, to interact with a database you must also install a package specific to that database.

#### Sql Server

```powershell
dotnet add .\src\Example.CLI\Example.CLI.csproj package Microsoft.EntityFrameworkCore.sqlserver
```

This will add a reference to the sql server entity framework package to the given project file. This only gives access to execute entity framework functionality at runtime.

```powershell
dotnet add .\src\Example.CLI\Example.CLI.csproj package Microsoft.entityframeworkcore.sqlserver.design
```

This adds a reference to the design time components for entity framework.

```powershell
dotnet add .\src\Example.CLI\Example.CLI.csproj package Microsoft.EntityFrameworkCore.tools
```

Enables Package Manager Console integration for interacting with EF similar to previous versions of the framework.

```powershell
dotnet add .\src\Example.CLI\Example.CLI.csproj package Microsoft.entityframeworkcore.tools.dotnet
```

Adds a reference to the dotnet CLI tools for interacting with EF. Due to a [bug in the CLI](https://github.com/dotnet/cli/issues/5998 ) implementation, this reference will be added wrong. You must edit the reference so that it looks like this:

```xml
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
</ItemGroup>
```

#### Sqlite

```powershell
dotnet add .\src\Example.CLI\Example.CLI.csproj package Microsoft.EntityFrameworkCore.Sqlite
```

Non-Microsoft data stores are easily supported using their integration libraries instead of the Sql Server version.

### Example Migration

```csharp
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EF.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

```

### CLI Based Execution

All Entity Framework migration commands must be excuted from inside Visual Studio's Package Manager Console or the CLI. CLI integration easy for CI systems to interact with the migrations to deploy them to an environment or generate data change scripts at build time.

#### Applying Migrations to Database

```powershell
dotnet ef database update
```

Will connect to the database and apply any migrations that have not already been applied.

#### Creating and Destroying Migrations

```powershell
dotnet ef migrations add MeaningfullName
```

Will look at the current state of our model and generate migration for any changes from the previous migration.

```powershell
dotnet ef migrations remove MeaningfullName
```

Will attempt to remove the migration from the project.

### Generating Change Scripts

```powershell
dotnet ef migrations script -i -o "Script0001-version_1.sql"
```

Will generate an idempotent sql script containging all the migrations. This script can be run on an empty database or an existing database, only the missing migrations will be applied.

```powershell
dotnet ef migrations script -o "Script0001-drop_tables.sql" Current Init
```

Will connect to the currently configured database and generate destructive scripts to drop all migrations applied from the `Current` migration to the `Init` migration.

**Note:** [Full CLI reference is located here](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet). You can do some cool stuff with the CLI.