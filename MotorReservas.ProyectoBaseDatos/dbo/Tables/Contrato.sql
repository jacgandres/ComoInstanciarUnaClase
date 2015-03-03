CREATE TABLE [dbo].[Contrato] (
    [IdContrato]       INT            IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]        INT            NOT NULL,
    [IdEstadoContrato] INT            NOT NULL,
    [Descripcion]      VARCHAR (2000) NOT NULL,
    [Valor]            DECIMAL (10)   NOT NULL,
    [FechaInicial]     DATETIME       NOT NULL,
    [FechaFinal]       DATETIME       NOT NULL,
    [PlazoEjecucion]   INT            NOT NULL,
    [Activo]           BIT            NOT NULL,
    [FechaRegistro]    DATETIME       CONSTRAINT [DF__Contrato__FechaR__33D4B598] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__Contrato__8569F05ADAF63EDD] PRIMARY KEY CLUSTERED ([IdContrato] ASC),
    CONSTRAINT [FK_Contrato_Empresa] FOREIGN KEY ([IdEmpresa]) REFERENCES [dbo].[Empresa] ([IdEmpresa]),
    CONSTRAINT [FK_Contrato_EstadoContrato] FOREIGN KEY ([IdEstadoContrato]) REFERENCES [dbo].[EstadoContrato] ([IdEstadoContrato])
);

