CREATE TABLE [dbo].[Perfil] (
    [IdPerfil]      INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (100) NOT NULL,
    [IdFacebook]    VARCHAR (200) CONSTRAINT [DF__Perfil__IdFacebo__1CF15040] DEFAULT (NULL) NULL,
    [IdTwitter]     VARCHAR (100) CONSTRAINT [DF__Perfil__IdTwitte__1DE57479] DEFAULT (NULL) NULL,
    [IdInstagram]   VARCHAR (100) CONSTRAINT [DF__Perfil__IdInstag__1ED998B2] DEFAULT (NULL) NULL,
    [IdGoogle]      VARCHAR (100) CONSTRAINT [DF__Perfil__IdGoogle__1FCDBCEB] DEFAULT (NULL) NULL,
    [Activo]        BIT           NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF__Perfil__FechaReg__20C1E124] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Perfil__C7BD5CC192EAF448] PRIMARY KEY CLUSTERED ([IdPerfil] ASC)
);

