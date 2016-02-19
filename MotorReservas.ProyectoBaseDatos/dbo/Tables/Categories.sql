CREATE TABLE [dbo].[Categories] (
    [CategoryId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [LogId]      BIGINT         NOT NULL,
    [Categories] VARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_Categories_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[Logs] ([LogId])
);

