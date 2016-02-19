CREATE TABLE [dbo].[Modulos_Tiene_Rol] (
    [IdModulos_Tiene_Rol] INT      IDENTITY (1, 1) NOT NULL,
    [IdRol]               INT      NOT NULL,
    [IdModulo]            INT      NOT NULL,
    [FechaRegistro]       DATETIME CONSTRAINT [DF_Modulos_Tiene_Rol_FechaRegistro] DEFAULT (getdate()) NOT NULL,
    [Activo]              BIT      NOT NULL,
    CONSTRAINT [PK__Modulos___8C33D38C47339281] PRIMARY KEY CLUSTERED ([IdModulos_Tiene_Rol] ASC, [IdRol] ASC, [IdModulo] ASC),
    CONSTRAINT [FK_Modulos_Tiene_Rol_Modulo] FOREIGN KEY ([IdModulo]) REFERENCES [dbo].[Modulo] ([IdModulo]) ON DELETE CASCADE,
    CONSTRAINT [FK_Modulos_Tiene_Rol_Rol] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Rol] ([IdRol]) ON DELETE CASCADE
);







