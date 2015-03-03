CREATE TABLE [dbo].[Diccionario] (
    [IdDiccionario] INT           IDENTITY (1, 1) NOT NULL,
    [Llave]         VARCHAR (4)   CONSTRAINT [DF__Diccionar__Llave__48CFD27E] DEFAULT (NULL) NOT NULL,
    [Nombre]        VARCHAR (50)  CONSTRAINT [DF__Diccionar__Nombr__49C3F6B7] DEFAULT (NULL) NOT NULL,
    [Descripcion]   VARCHAR (100) CONSTRAINT [DF__Diccionar__Descr__4AB81AF0] DEFAULT (NULL) NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF__Diccionar__Fecha__4BAC3F29] DEFAULT (getdate()) NOT NULL,
    [Activo]        BIT           CONSTRAINT [DF__Diccionar__Activ__4CA06362] DEFAULT (NULL) NOT NULL,
    [IdProducto]    INT           CONSTRAINT [DF__Diccionar__IdPro__4D94879B] DEFAULT (NULL) NULL,
    [IdServicio]    INT           CONSTRAINT [DF__Diccionar__IdSer__4E88ABD4] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Dicciona__476FF450F2E10387] PRIMARY KEY CLUSTERED ([IdDiccionario] ASC),
    CONSTRAINT [FK_Diccionario_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto]),
    CONSTRAINT [FK_Diccionario_Servicio] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[Servicio] ([IdServicio])
);

