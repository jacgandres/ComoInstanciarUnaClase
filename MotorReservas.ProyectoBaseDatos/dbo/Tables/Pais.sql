CREATE TABLE [dbo].[Pais] (
    [IdPais]        INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (100) NOT NULL,
    [FecheRegistro] DATETIME      CONSTRAINT [DF__Pais__FecheRegis__145C0A3F] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Pais__FC850A7B2609A88E] PRIMARY KEY CLUSTERED ([IdPais] ASC)
);

