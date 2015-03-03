CREATE TABLE [dbo].[Sede] (
    [IdSede]        INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50)  CONSTRAINT [DF__Sede__Nombre__68487DD7] DEFAULT (NULL) NOT NULL,
    [IdEmpresa]     INT           NOT NULL,
    [Activo]        BIT           CONSTRAINT [DF__Sede__Activo__693CA210] DEFAULT (NULL) NOT NULL,
    [Direccion]     VARCHAR (100) CONSTRAINT [DF__Sede__Direccion__6A30C649] DEFAULT (NULL) NOT NULL,
    [Telefono]      VARCHAR (15)  CONSTRAINT [DF__Sede__Telefono__6B24EA82] DEFAULT (NULL) NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF__Sede__FechaRegis__6C190EBB] DEFAULT (getdate()) NOT NULL,
    [IdCiudad]      INT           NOT NULL,
    CONSTRAINT [PK__Sede__A7780DFF87C55F7D] PRIMARY KEY CLUSTERED ([IdSede] ASC),
    CONSTRAINT [FK_Sede_Ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [dbo].[Ciudad] ([IdCiudad]),
    CONSTRAINT [FK_Sede_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa])
);

