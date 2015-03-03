CREATE TABLE [dbo].[TipoReserva] (
    [IdTipoReserva] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50)  NOT NULL,
    [Descripcion]   VARCHAR (100) CONSTRAINT [DF__TipoReser__Descr__5535A963] DEFAULT (NULL) NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF__TipoReser__Fecha__5629CD9C] DEFAULT (getdate()) NOT NULL,
    [Activo]        BIT           NOT NULL,
    CONSTRAINT [PK__TipoRese__F0D6565694D3FFFF] PRIMARY KEY CLUSTERED ([IdTipoReserva] ASC)
);

