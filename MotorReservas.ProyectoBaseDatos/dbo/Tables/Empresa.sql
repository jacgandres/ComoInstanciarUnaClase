CREATE TABLE [dbo].[Empresa] (
    [IdEmpresa]      INT           IDENTITY (1, 1) NOT NULL,
    [IdPerfil]       INT           NOT NULL,
    [IdCiudad]       INT           NOT NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [Identificacion] VARCHAR (100) NOT NULL,
    [Telefono]       VARCHAR (15)  CONSTRAINT [DF__Empresa__Telefon__2C3393D0] DEFAULT (NULL) NOT NULL,
    [Email]          VARCHAR (100) NOT NULL,
    [Direccion]      VARCHAR (100) CONSTRAINT [DF__Empresa__Direcci__2D27B809] DEFAULT (NULL) NOT NULL,
    [Activo]         BIT           NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__Empresa__FechaRe__2E1BDC42] DEFAULT (getdate()) NOT NULL,
    [UrlImagen1]     VARCHAR (100) CONSTRAINT [DF__Empresa__UrlImag__2F10007B] DEFAULT (NULL) NULL,
    [UrlImagen2]     VARCHAR (100) CONSTRAINT [DF__Empresa__UrlImag__300424B4] DEFAULT (NULL) NULL,
    [UrlImagen3]     VARCHAR (100) CONSTRAINT [DF__Empresa__UrlImag__30F848ED] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Empresa__5EF4033E930C8123] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC),
    CONSTRAINT [FK_Empresa_Ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [dbo].[Ciudad] ([IdCiudad]),
    CONSTRAINT [FK_Empresa_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfil] ([IdPerfil])
);

