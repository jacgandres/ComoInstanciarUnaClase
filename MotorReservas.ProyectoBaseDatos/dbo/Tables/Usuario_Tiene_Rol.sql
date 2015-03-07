CREATE TABLE [dbo].[Usuario_Tiene_Rol] (
    [IdUsuario_Tiene_Rol] INT      IDENTITY (1, 1) NOT NULL,
    [IdRol]               INT      NOT NULL,
    [IdUsuario]           INT      NOT NULL,
    [FechaRegistro]       DATETIME CONSTRAINT [DF_Usuario_Tiene_Rol_FechaRegistro] DEFAULT (getdate()) NOT NULL,
    [Activo]              BIT      NOT NULL,
    CONSTRAINT [PK__Usuario___75179431E7B4DE11] PRIMARY KEY CLUSTERED ([IdUsuario_Tiene_Rol] ASC, [IdRol] ASC, [IdUsuario] ASC),
    CONSTRAINT [FK_Usuario_Tiene_Rol_Rol] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Rol] ([IdRol]) ON DELETE CASCADE,
    CONSTRAINT [FK_Usuario_Tiene_Rol_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario]) ON DELETE CASCADE
);







