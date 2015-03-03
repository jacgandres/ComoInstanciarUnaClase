CREATE TABLE [dbo].[FormaPago] (
    [IdFormaPago]   INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (100) NOT NULL,
    [Activo]        BIT           NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF__FormaPago__Fecha__5165187F] DEFAULT (getdate()) NOT NULL,
    [Nombre]        VARCHAR (50)  CONSTRAINT [DF__FormaPago__Nombr__52593CB8] DEFAULT (NULL) NOT NULL,
    CONSTRAINT [PK__FormaPag__C777CA683774583B] PRIMARY KEY CLUSTERED ([IdFormaPago] ASC)
);

