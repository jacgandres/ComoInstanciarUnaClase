CREATE TABLE [dbo].[Servicio] (
    [IdServicio]     INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]      INT           NOT NULL,
    [Nombre]         VARCHAR (100) CONSTRAINT [DF__Servicio__Nombre__4222D4EF] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__Servicio__FechaR__4316F928] DEFAULT (NULL) NOT NULL,
    [UrlImagen1]     VARCHAR (100) CONSTRAINT [DF__Servicio__UrlIma__440B1D61] DEFAULT (NULL) NULL,
    [UrlImagen2]     VARCHAR (100) CONSTRAINT [DF__Servicio__UrlIma__44FF419A] DEFAULT (NULL) NULL,
    [UrlImagen3]     VARCHAR (100) CONSTRAINT [DF__Servicio__UrlIma__45F365D3] DEFAULT (NULL) NULL,
    [IdTipoServicio] INT           NOT NULL,
    CONSTRAINT [PK__Servicio__2DCCF9A239EF5B66] PRIMARY KEY CLUSTERED ([IdServicio] ASC),
    CONSTRAINT [FK_Servicio_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa]),
    CONSTRAINT [FK_Servicio_TipoServicio] FOREIGN KEY ([IdTipoServicio]) REFERENCES [dbo].[TipoServicio] ([IdTipoServicio])
);

