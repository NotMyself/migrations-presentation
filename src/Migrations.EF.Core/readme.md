dotnet ef migrations add Init

dotnet ef database update

dotnet ef migrations script -i -o "Script0002-version_1.sql"