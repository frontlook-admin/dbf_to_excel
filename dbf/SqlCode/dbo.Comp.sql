CREATE TABLE [dbo].[Comp] (
    [CompId]         INT           NOT NULL,
    [Name]           VARCHAR (MAX) NOT NULL,
    [CompPath]       VARCHAR (MAX) NOT NULL,
    [BackInterval]   INT           NOT NULL,
    [IntervalType]   VARCHAR (30)  NOT NULL,
    [BackUpLocation] VARCHAR (MAX) NOT NULL,
    [LastBackup]     DATETIME      NOT NULL,
    [Active]         BIT           NOT NULL, 
    CONSTRAINT [PK_Comp] PRIMARY KEY ([CompId])
);

