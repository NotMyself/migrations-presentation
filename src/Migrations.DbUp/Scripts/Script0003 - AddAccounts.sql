CREATE TABLE [dbo].[Accounts] (
    [Id] [int] NOT NULL IDENTITY,
    [Type] [int] NOT NULL,
    [Created] [datetime] NOT NULL,
    [Updated] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[Transactions] ADD [Account_Id] [int]
CREATE INDEX [IX_Account_Id] ON [dbo].[Transactions]([Account_Id])
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [FK_dbo.Transactions_dbo.Accounts_Account_Id] FOREIGN KEY ([Account_Id]) REFERENCES [dbo].[Accounts] ([Id])