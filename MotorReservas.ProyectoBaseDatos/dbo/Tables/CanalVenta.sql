CREATE TABLE [dbo].[CanalVenta] (
    [IdCanalVenta]  INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50)  CONSTRAINT [DF__CanalVent__Nombr__108B795B] DEFAULT (NULL) NOT NULL,
    [FechaRegistro] DATETIME      CONSTRAINT [DF__CanalVent__Fecha__117F9D94] DEFAULT (getdate()) NOT NULL,
    [Activo]        BIT           NOT NULL,
    [Descripcion]   VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CanalVenta] PRIMARY KEY CLUSTERED ([IdCanalVenta] ASC)
);

