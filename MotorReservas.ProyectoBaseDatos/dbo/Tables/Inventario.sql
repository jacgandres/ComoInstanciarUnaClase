CREATE TABLE [dbo].[Inventario] (
    [IdInventario]     INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]           VARCHAR (100)   CONSTRAINT [DF__Inventari__Nombr__60A75C0F] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]    DATETIME        CONSTRAINT [DF__Inventari__Fecha__619B8048] DEFAULT (getdate()) NOT NULL,
    [IdEmpresa]        INT             CONSTRAINT [DF__Inventari__IdEmp__628FA481] DEFAULT (NULL) NOT NULL,
    [IdTipoInventario] INT             NOT NULL,
    [Cantidad]         DECIMAL (18, 2) NULL,
    CONSTRAINT [PK__Inventar__1927B20C15C6666B] PRIMARY KEY CLUSTERED ([IdInventario] ASC),
    CONSTRAINT [FK_Inventario_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa]),
    CONSTRAINT [FK_Inventario_TipoInventario] FOREIGN KEY ([IdTipoInventario]) REFERENCES [dbo].[TipoInventario] ([IdTtipoInventario])
);



