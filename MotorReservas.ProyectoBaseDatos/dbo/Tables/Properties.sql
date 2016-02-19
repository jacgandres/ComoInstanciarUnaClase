CREATE TABLE [dbo].[Properties] (
    [PropertyId]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [LogId]              BIGINT         NOT NULL,
    [ExtendedProperties] VARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED ([PropertyId] ASC),
    CONSTRAINT [FK_Properties_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[Logs] ([LogId])
);

