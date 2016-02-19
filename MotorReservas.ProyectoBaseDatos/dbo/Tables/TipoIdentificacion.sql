CREATE TABLE [dbo].[TipoIdentificacion] (
    [IdTipoIdentificacion] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]               VARCHAR (100) NOT NULL,
    [Activo]               BIT           NOT NULL,
    [FechaRegistro]        DATETIME      CONSTRAINT [DF__TipoIdent__Fecha__239E4DCF] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__TipoIden__F521C6A8B8159431] PRIMARY KEY CLUSTERED ([IdTipoIdentificacion] ASC)
);

