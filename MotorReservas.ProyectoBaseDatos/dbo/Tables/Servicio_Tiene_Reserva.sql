CREATE TABLE [dbo].[Servicio_Tiene_Reserva] (
    [IdServicio_Tiene_Reserva] INT      IDENTITY (1, 1) NOT NULL,
    [IdReserva]                INT      CONSTRAINT [DF__Servicio___IdRes__6EF57B66] DEFAULT (NULL) NOT NULL,
    [IdServicio]               INT      CONSTRAINT [DF__Servicio___IdSer__6FE99F9F] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]            DATETIME CONSTRAINT [DF__Servicio___Fecha__70DDC3D8] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Servicio__52E27A98FCD5F8EE] PRIMARY KEY CLUSTERED ([IdServicio_Tiene_Reserva] ASC),
    CONSTRAINT [FK_Servicio_Tiene_Reserva_Reserva] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[Reserva] ([IdReserva]),
    CONSTRAINT [FK_Servicio_Tiene_Reserva_Servicio] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[Servicio] ([IdServicio])
);

