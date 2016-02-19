CREATE TABLE [dbo].[DetalleReserva] (
    [IdDetalleReserva] INT      IDENTITY (1, 1) NOT NULL,
    [FechaRegistro]    DATETIME CONSTRAINT [DF__DetalleRe__Fecha__36B12243] DEFAULT (getdate()) NOT NULL,
    [Activo]           BIT      CONSTRAINT [DF__DetalleRe__Activ__37A5467C] DEFAULT (NULL) NOT NULL,
    CONSTRAINT [PK__DetalleR__388ACBC7A1FB60CC] PRIMARY KEY CLUSTERED ([IdDetalleReserva] ASC)
);

