CREATE TABLE [dbo].[TipoProducto] (
    [IdTipoProducto] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (50)  CONSTRAINT [DF__TipoProdu__Nombr__787EE5A0] DEFAULT (NULL) NOT NULL,
    [Descripcion]    VARCHAR (100) CONSTRAINT [DF__TipoProdu__Descr__797309D9] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__TipoProdu__Fecha__7A672E12] DEFAULT (getdate()) NOT NULL,
    [Activo]         BIT           NOT NULL,
    CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED ([IdTipoProducto] ASC)
);

