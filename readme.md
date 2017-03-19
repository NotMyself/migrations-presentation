# Database Migrations

## Why

> Migrations are about evolutionary database design that rely on applying continuous
> integration and automated refactoring to database development, together with a  close collaboration between DBAs and application developers. The techniques work in both pre-production and released systems, in green field projects as well as legacy systems.
>
> - [Martin Fowler](https://martinfowler.com/), [Evolutionary Database Design](https://martinfowler.com/articles/evodb.html)

> We began around 2000 with a project whose database ended up with around 600 tables. As we worked on this project we developed techniques that allowed to change the schema and migrate existing data comfortably. This allowed our database to be completely flexible and evolvable.
>
> - [Martin Fowler](https://martinfowler.com/), [Evolutionary Database Design](https://martinfowler.com/articles/evodb.html)

## Frameworks & Languages Migrations

* Ruby on Rails - Ruby, [Active Record Migrations](http://edgeguides.rubyonrails.org/active_record_migrations.html)
* Groovy - Java, [Automatic Database Migration](http://docs.grails.org/latest/guide/conf.html#automaticDatabaseMigration)
* Django - Python, [Migrations](https://docs.djangoproject.com/en/1.10/topics/migrations/)
* [Migrate](https://github.com/mattes/migrate) - Go
* [db-migrate](https://github.com/db-migrate/node-db-migrate) - Node.js

## Common Features of Migrations

* **Database Versioning** - Migration frameworks typically keep a version table in a migrated database indicating the migration version applied to it. Making it easy to tell if your current codebase is compatible.

* **Downgrading** - Migration frameworks typically offer a method of downgrading to an earlier version of the schema. This makes it easy to push changes to a database at design time and remove them if the feature is rolled back.

* **Persistence Ignorance** - Migration frameworks frequently support multiple relational database vendors. A single set of migrations can be applied to Sql Server, Postgres and SQLite. Mature frameworks even support dialects like Sql Server 2014 vs 2016. This allows the framework to make good choices about syntax and features.

* **Repeatibilty** - Migrations can be applied over and over again creating the exact same database. So they can be run in developmnet, test, uat and production with the exact same result.

* **Consistency** - Some migration frameworks generate migrations based on conventions from your model code. These conventions are applied consistently accross the entire database. For example, a tables primary key will always be 'Id'. But if you wish, these conventions are overridable and applied universally. For example, you want your primary key to always be `EntityNameId` or your tables to always start with `TBL_Entityname`.

* **Idempotence** - Migration frameworks will typically do "the right thing" when applying migrations. If a migration has been run once, it will not be run again.

## Migrations in .NET

* **[FluentMigrator](src/Migrations.FluentMigrator/readme.md)** - One of the first migration frameworks that I was aware of for .net. Migrations are code based and can be applied to a variety of relational databases. Very CI friendly as well.

* **[Entity Framework Migrations](src/Migrations.EF/readme.md)** - The first official migrations framework built into the .net platform. Specific to Sql Server, but can be configured to target specific variants of it. Not very CI friendly.

* **[Entity Framework Core Migrations](src/Migrations.EF.Core/readme.md)** - Complete rewrite of EF that can be used cross platform. Able to target multiple relational databases. CLI is very CI friendly as well as scriptable.

* **[DbUp](src/Migrations.DbUp/readme.md)** - Super light weight migrations that can target anything ADO.NET can connect to and you can write sql scripts against. Very CI friendly. It is a good starting place for a team unfamiliar with migrations as a concept or teams starting with an existing database.
