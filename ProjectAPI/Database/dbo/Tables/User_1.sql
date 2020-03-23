CREATE TABLE [dbo].[User] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Role]     INT          NOT NULL,
    CONSTRAINT [PK__User__3214EC07E3A08803] PRIMARY KEY CLUSTERED ([Id] ASC)
);



