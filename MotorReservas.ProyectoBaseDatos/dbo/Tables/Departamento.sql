CREATE TABLE [dbo].[Departamento] (
    [IdDepartamento] INT           IDENTITY (1, 1) NOT NULL,
    [IdPais]         INT           NOT NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__departame__Fecha__173876EA] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__departam__C225F98D62C6DC12] PRIMARY KEY CLUSTERED ([IdDepartamento] ASC),
    CONSTRAINT [FK_Departamento_Pais] FOREIGN KEY ([IdPais]) REFERENCES [dbo].[Pais] ([IdPais])
);

