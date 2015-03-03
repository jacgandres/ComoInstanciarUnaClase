CREATE TABLE [dbo].[Producto_Tiene_Reserva] (
    [IdProducto_Tiene_Reserva] INT      IDENTITY (1, 1) NOT NULL,
    [IdReserva]                INT      NOT NULL,
    [IdProducto]               INT      NOT NULL,
    [FechaRegistro]            DATETIME CONSTRAINT [DF__Producto___Fecha__656C112C] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Producto__A148E4ED070A728D] PRIMARY KEY CLUSTERED ([IdProducto_Tiene_Reserva] ASC),
    CONSTRAINT [FK_Producto_Tiene_Reserva_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto]),
    CONSTRAINT [FK_Producto_Tiene_Reserva_Reserva] FOREIGN KEY ([IdReserva]) REFERENCES [dbo].[Reserva] ([IdReserva])
);

