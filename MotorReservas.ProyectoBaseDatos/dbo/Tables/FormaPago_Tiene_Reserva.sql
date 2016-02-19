CREATE TABLE [dbo].[FormaPago_Tiene_Reserva] (
    [IdFormaPago_Tiene_Reserva] INT      IDENTITY (1, 1) NOT NULL,
    [IdReserva]                 INT      NOT NULL,
    [Activo]                    BIT      CONSTRAINT [DF__FormaPago__Activ__5CD6CB2B] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]             DATETIME CONSTRAINT [DF__FormaPago__Fecha__5DCAEF64] DEFAULT (getdate()) NOT NULL,
    [IdFormaDePago]             INT      NOT NULL,
    CONSTRAINT [PK_FormaPago_Tiene_Reserva] PRIMARY KEY CLUSTERED ([IdFormaPago_Tiene_Reserva] ASC),
    CONSTRAINT [FK_FormaPago_Tiene_Reserva_FormaPago] FOREIGN KEY ([IdFormaDePago]) REFERENCES [dbo].[FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_FormaPago_Tiene_Reserva_Reserva] FOREIGN KEY ([IdReserva]) REFERENCES [dbo].[Reserva] ([IdReserva])
);

