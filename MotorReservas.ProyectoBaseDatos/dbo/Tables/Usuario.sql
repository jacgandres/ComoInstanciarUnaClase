CREATE TABLE [dbo].[Usuario] (
    [IdUsuario]         INT           IDENTITY (1, 1) NOT NULL,
    [Clave]             VARCHAR (50)  NOT NULL,
    [Correo]            VARCHAR (50)  NOT NULL,
    [Activo]            BIT           NOT NULL,
    [FechaRegistro]     DATETIME      CONSTRAINT [DF_Usuario_FechaRegistro] DEFAULT (getdate()) NOT NULL,
    [IdEmpresa]         INT           NULL,
    [UrlImagen1]        VARCHAR (100) NULL,
    [UrlImagen2]        VARCHAR (100) CONSTRAINT [DF__Usuario__UrlImag__04E4BC85] DEFAULT (NULL) NULL,
    [UrlImagen3]        VARCHAR (100) CONSTRAINT [DF__Usuario__UrlImag__05D8E0BE] DEFAULT (NULL) NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [FechaUltimaSesion] DATETIME      NULL,
    [Nombre]            VARCHAR (50)  NOT NULL,
    [Apellido]          VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK__Usuario__5B65BF97B8314691] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_Usuario_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa])
);

