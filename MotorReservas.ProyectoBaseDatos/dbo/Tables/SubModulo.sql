CREATE TABLE [dbo].[SubModulo] (
    [IdSubModulo]     INT           NOT NULL,
    [IdModulo]        INT           NOT NULL,
    [SubModuloNombre] VARCHAR (50)  NOT NULL,
    [FechaRegistro]   DATETIME      CONSTRAINT [DF_SubModulo_FechaRegistro] DEFAULT (getdate()) NOT NULL,
    [Activo]          BIT           CONSTRAINT [DF_SubModulo_Activo] DEFAULT ((1)) NOT NULL,
    [Descripcion]     VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SubModulo] PRIMARY KEY CLUSTERED ([IdSubModulo] ASC),
    CONSTRAINT [FK_SubModulo_Modulo] FOREIGN KEY ([IdModulo]) REFERENCES [dbo].[Modulo] ([IdModulo]) ON DELETE CASCADE
);



