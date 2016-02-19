CREATE TABLE [dbo].[Reserva] (
    [IdReserva]        INT      NOT NULL,
    [IdEmpresa]        INT      NOT NULL,
    [IdCliente]        INT      NOT NULL,
    [IdDetalleReserva] INT      NOT NULL,
    [Activo]           BIT      CONSTRAINT [DF__reserva__Activo__59063A47] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]    DATETIME CONSTRAINT [DF__reserva__FechaRe__59FA5E80] DEFAULT (getdate()) NOT NULL,
    [IdCanalVenta]     INT      NOT NULL,
    [IdTipoReserva]    INT      NOT NULL,
    CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED ([IdReserva] ASC),
    CONSTRAINT [FK_Reserva_CanalVenta] FOREIGN KEY ([IdCanalVenta]) REFERENCES [dbo].[CanalVenta] ([IdCanalVenta]),
    CONSTRAINT [FK_Reserva_DetalleReserva] FOREIGN KEY ([IdDetalleReserva]) REFERENCES [dbo].[DetalleReserva] ([IdDetalleReserva]),
    CONSTRAINT [FK_Reserva_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa]),
    CONSTRAINT [FK_Reserva_TipoReserva] FOREIGN KEY ([IdTipoReserva]) REFERENCES [dbo].[TipoReserva] ([IdTipoReserva])
);

