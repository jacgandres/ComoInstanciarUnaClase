CREATE TABLE [dbo].[Logs] (
    [LogId]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [IsTrace]              BIT            NULL,
    [ModuleId]             INT            NULL,
    [ElapsedTime]          FLOAT (53)     NULL,
    [RecordLocator]        VARCHAR (10)   NULL,
    [Action]               VARCHAR (100)  NULL,
    [AppUserId]            VARCHAR (50)   NULL,
    [appUsuarioNombre]     VARCHAR (50)   NULL,
    [FormattedMessage]     VARCHAR (3000) NULL,
    [Priority]             VARCHAR (500)  NULL,
    [Severity]             VARCHAR (500)  NULL,
    [Title]                VARCHAR (500)  NULL,
    [Type]                 VARCHAR (2000) NULL,
    [MessageExplicitError] VARCHAR (2000) NULL,
    [Status]               VARCHAR (500)  NULL,
    [StackTrace]           VARCHAR (2000) NULL,
    [Params]               VARCHAR (2000) NULL,
    [TracerGuid]           VARCHAR (100)  NULL,
    [TracerDate]           DATETIME       NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([LogId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [GUID_Indez]
    ON [dbo].[Logs]([TracerGuid] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);

