CREATE TABLE [dbo].[TipoInventario] (
    [IdTtipoInventario] INT           IDENTITY (1, 1) NOT NULL,
    [FechaRegistro]     DATETIME      CONSTRAINT [DF__TipoInven__Fecha__74AE54BC] DEFAULT (getdate()) NOT NULL,
    [Nombre]            VARCHAR (100) CONSTRAINT [DF__TipoInven__Nombr__75A278F5] DEFAULT (NULL) NOT NULL,
    CONSTRAINT [PK__TipoInve__75DC544889A825F4] PRIMARY KEY CLUSTERED ([IdTtipoInventario] ASC)
);

