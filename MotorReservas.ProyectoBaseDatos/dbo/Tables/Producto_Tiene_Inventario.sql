CREATE TABLE [dbo].[Producto_Tiene_Inventario] (
    [IdProducto_Tiene_Inventario] INT      IDENTITY (1, 1) NOT NULL,
    [IdProducto]                  INT      NOT NULL,
    [IdInventario]                INT      NOT NULL,
    [FechaRegistro]               DATETIME CONSTRAINT [DF_Producto_Tiene_Inventario_FechaRegistro] DEFAULT (getdate()) NOT NULL,
    [Activo]                      BIT      NOT NULL,
    CONSTRAINT [PK_Producto_Tiene_Inventario] PRIMARY KEY CLUSTERED ([IdProducto_Tiene_Inventario] ASC, [IdProducto] ASC, [IdInventario] ASC),
    CONSTRAINT [FK_Producto_Tiene_Inventario_Inventario] FOREIGN KEY ([IdInventario]) REFERENCES [dbo].[Inventario] ([IdInventario]),
    CONSTRAINT [FK_Producto_Tiene_Inventario_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto])
);



