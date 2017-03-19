CREATE TABLE [dbo].[Customers] (
    [Id] [int] NOT NULL IDENTITY,
    [FirstName] [nvarchar](max),
    [LastName] [nvarchar](max),
    [Created] [datetime] NOT NULL,
    [Updated] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY ([Id])
	)