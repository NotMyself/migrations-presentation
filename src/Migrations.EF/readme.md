Add-Migration Foo

Update-Database -Verbose

Update-Database -Script -SourceMigration: $InitialDatabase