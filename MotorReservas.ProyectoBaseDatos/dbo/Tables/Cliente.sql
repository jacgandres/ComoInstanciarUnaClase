CREATE TABLE [dbo].[Cliente] (
    [IdCliente]            INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]               VARCHAR (100) NOT NULL,
    [Telefono]             VARCHAR (10)  NOT NULL,
    [Email]                VARCHAR (100) NOT NULL,
    [IdTipoIdentificacion] INT           NOT NULL,
    [Identificacion]       VARCHAR (100) NOT NULL,
    [IdPerfil]             INT           NOT NULL,
    [IdCiudad]             INT           NOT NULL,
    [Activo]               BIT           NOT NULL,
    [FechaRegistro]        DATETIME      CONSTRAINT [DF__Cliente__FechaRe__267ABA7A] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Cliente__D5946642A376137F] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [FK_Cliente_Ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [dbo].[Ciudad] ([IdCiudad]),
    CONSTRAINT [FK_Cliente_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfil] ([IdPerfil]),
    CONSTRAINT [FK_Cliente_TipoIdentificacion] FOREIGN KEY ([IdTipoIdentificacion]) REFERENCES [dbo].[TipoIdentificacion] ([IdTipoIdentificacion])
);

