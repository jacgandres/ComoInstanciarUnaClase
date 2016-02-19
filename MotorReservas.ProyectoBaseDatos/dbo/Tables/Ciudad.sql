CREATE TABLE [dbo].[Ciudad] (
    [IdCiudad]       INT           IDENTITY (1, 1) NOT NULL,
    [IdDepartamento] INT           NOT NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__Ciudad__FechaReg__1A14E395] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Ciudad__D4D3CCB094B5C170] PRIMARY KEY CLUSTERED ([IdCiudad] ASC),
    CONSTRAINT [FK_Ciudad_Departamento] FOREIGN KEY ([IdDepartamento]) REFERENCES [dbo].[Departamento] ([IdDepartamento])
);

