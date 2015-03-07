CREATE TABLE [dbo].[Rol] (
    [IdRol]         INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50)  NOT NULL,
    [FechaRegistro] DATETIME      NOT NULL,
    [Activo]        DATETIME      NOT NULL,
    [Descripcion]   VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED ([IdRol] ASC)
);

