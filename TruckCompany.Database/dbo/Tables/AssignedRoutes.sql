CREATE TABLE [dbo].[AssignedRoutes] (
    [Id]         INT              NOT NULL,
    [TruckerId]  UNIQUEIDENTIFIER NOT NULL,
    [LocationId] INT              NOT NULL,
    [StatusId]   INT              NOT NULL,
    CONSTRAINT [PK_AssignedRoutes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AssignedRoutes_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id]),
    CONSTRAINT [FK_AssignedRoutes_Statuses] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statuses] ([Id]),
    CONSTRAINT [FK_AssignedRoutes_Truckers] FOREIGN KEY ([TruckerId]) REFERENCES [dbo].[Truckers] ([Id])
);

