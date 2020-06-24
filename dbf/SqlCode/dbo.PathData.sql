CREATE TABLE [dbo].[PathData] (
    [PathId] INT            NOT NULL,
    [CompId] INT            NOT NULL,
    [Path]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_PathData] PRIMARY KEY ([PathId]),
    CONSTRAINT [FK_PathData_Comp] FOREIGN KEY ([CompId]) REFERENCES [Comp]([CompId]) 
);

