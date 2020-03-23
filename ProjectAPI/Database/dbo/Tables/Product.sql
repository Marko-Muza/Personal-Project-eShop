CREATE TABLE [dbo].[Product] (
    [Id]               INT           NOT NULL,
    [Code]             INT           NOT NULL,
    [IsActive]         BIT           NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [Image]            VARCHAR (200) NOT NULL,
    [ShortDescription] VARCHAR (250) NOT NULL,
    [Price]            MONEY         NOT NULL,
    [ShippingPrice]    MONEY         NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

