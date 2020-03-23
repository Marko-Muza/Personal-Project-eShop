CREATE TABLE [dbo].[CartProduct] (
    [Id]        INT NOT NULL,
    [CartId]    INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [FK_CartProduct_Cart] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Cart] ([Id]),
    CONSTRAINT [FK_CartProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

