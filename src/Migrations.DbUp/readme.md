# DbUp Migrations

DbUp is a super light weight migrations framework. It supports any database that can be connected to via ADO.NET. If you got a connection string, it can try to run. It only supports forward migration and has [actively ignored calls](https://github.com/DbUp/DbUp/issues/42) to offer downgrade functionalty. You reference DbUp in a a command line application, which depending on how you write it can make it highly scriptable and CI friendly.

## About

- Maintained By: [Paul Stovell](https://github.com/PaulStovell) & [Others](https://github.com/DbUp/DbUp/graphs/contributors)
- [NuGet](https://www.nuget.org/packages/dbup/)
- [Source](https://github.com/DbUp/DbUp)
- [Documentation](http://dbup.readthedocs.io/en/stable/)

### Installation

```powershell
Install-Package dbup
```

### Example Migration

```sql
CREATE TABLE [dbo].[Transactions] (
        [Id] [int] NOT NULL IDENTITY,
        [Amount] [decimal](18, 2) NOT NULL,
        [Type] [int] NOT NULL,
        [Created] [datetime] NOT NULL,
        [Updated] [datetime] NOT NULL,
        CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY ([Id])
		)

```

### Example Execution Host

```csharp
using System.Linq;
using System.Configuration;
using DbUp;
using System.Reflection;
using System;

namespace Migrations.DbUp
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault()
                ??  ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);

                Console.ResetColor();
                Console.ReadLine();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            Console.ReadLine();
            return 0;
        }
    }
}
```

### CLI Based Execution

DbUp can be embeded in a console application. This means you can make it as scriptable as you need. It will track what scripts have been applied to a given database and only execute missing ones. Can be executed right in your release process.


#### Creating and Destroying Migrations

Adding a new migration is as simple as creating a new sql script. By convention the scripts should be named `Script0001-MeaningfullName.sql` where the first portion of the name is an incrementing number that is used to sort script execution.

Include the script in your project and mark it as an Embedded Resource. This will prevent duplicate names and embed the script in the build executable or class library for portability.

Removing a migration from the project does not remove it from a database it has already been applied to. You have to manually remove the change. Best practice is to create a new script that removes the old changes.

