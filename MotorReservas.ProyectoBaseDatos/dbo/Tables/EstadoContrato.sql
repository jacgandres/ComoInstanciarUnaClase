CREATE TABLE [dbo].[EstadoContrato] (
    [IdEstadoContrato] INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]      VARCHAR (100) NOT NULL,
    [Activo]           BIT           NOT NULL,
    [FechaRegistro]    DATETIME      CONSTRAINT [DF__EstadoCon__Fecha__29572725] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__EstadoCo__E4769D4B106DC9E3] PRIMARY KEY CLUSTERED ([IdEstadoContrato] ASC)
);

