ALTER TABLE [dbo].[Accounts] ADD [Customer_Id] [int]
CREATE INDEX [IX_Customer_Id] ON [dbo].[Accounts]([Customer_Id])
ALTER TABLE [dbo].[Accounts] ADD CONSTRAINT [FK_dbo.Accounts_dbo.Customers_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers] ([Id])