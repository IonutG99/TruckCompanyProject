CREATE TABLE [dbo].[Truckers] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   VARCHAR (50)     NOT NULL,
    [LastName]    VARCHAR (50)     NOT NULL,
    [PhoneNumber] VARCHAR (50)     NULL,
    CONSTRAINT [PK_Truckers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

