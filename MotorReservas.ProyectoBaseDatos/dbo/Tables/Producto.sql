CREATE TABLE [dbo].[Producto] (
    [IdProducto]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (100) CONSTRAINT [DF__producto__Nombre__3A81B327] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__producto__FechaR__3B75D760] DEFAULT (getdate()) NOT NULL,
    [Activo]         BIT           CONSTRAINT [DF__producto__Activo__3C69FB99] DEFAULT (NULL) NOT NULL,
    [IdEmpresa]      INT           NOT NULL,
    [UrlImagen1]     VARCHAR (100) CONSTRAINT [DF__producto__UrlIma__3D5E1FD2] DEFAULT (NULL) NULL,
    [UrlImagen2]     VARCHAR (100) CONSTRAINT [DF__producto__UrlIma__3E52440B] DEFAULT (NULL) NULL,
    [UrlImagen3]     VARCHAR (100) CONSTRAINT [DF__producto__UrlIma__3F466844] DEFAULT (NULL) NULL,
    [IdTipoProducto] INT           NOT NULL,
    CONSTRAINT [PK__producto__098892109A249574] PRIMARY KEY CLUSTERED ([IdProducto] ASC),
    CONSTRAINT [FK_Producto_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa]),
    CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY ([IdTipoProducto]) REFERENCES [dbo].[TipoProducto] ([IdTipoProducto])
);

