CREATE TABLE [dbo].[ProductDetails] (
    [Id]            INT        NOT NULL,
    [ProductId]     INT        NOT NULL,
    [DatePublished] DATE       NOT NULL,
    [Condition]     NCHAR (10) NOT NULL,
    [Gender]        NCHAR (10) NOT NULL,
    [Color]         INT        NOT NULL,
    [Model]         INT        NOT NULL,
    [PublishedBy]   INT        NOT NULL,
    [ShippingFrom]  NCHAR (20) NOT NULL,
    CONSTRAINT [FK_ProductDetails_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_ProductDetails_User] FOREIGN KEY ([PublishedBy]) REFERENCES [dbo].[User] ([Id])
);

