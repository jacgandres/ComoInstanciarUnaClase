CREATE TABLE [dbo].[Modulo] (
    [IdModulo]      INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50)  NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF_Modulo_FechaRegistro] DEFAULT (getdate()) NOT NULL,
    [Activo]        BIT           NOT NULL,
    [Descripcion]   VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__Modulo__D9F15315A24337A1] PRIMARY KEY CLUSTERED ([IdModulo] ASC)
);

