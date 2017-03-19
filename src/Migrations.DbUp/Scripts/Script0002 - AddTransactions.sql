CREATE TABLE [dbo].[Transactions] (
        [Id] [int] NOT NULL IDENTITY,
        [Amount] [decimal](18, 2) NOT NULL,
        [Type] [int] NOT NULL,
        [Created] [datetime] NOT NULL,
        [Updated] [datetime] NOT NULL,
        CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY ([Id])
		)