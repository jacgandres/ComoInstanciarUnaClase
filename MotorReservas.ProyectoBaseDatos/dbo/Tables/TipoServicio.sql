CREATE TABLE [dbo].[TipoServicio] (
    [IdTipoServicio] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (50)  CONSTRAINT [DF__TipoServi__Nombr__7E37BEF6] DEFAULT (NULL) NOT NULL,
    [Descripcion]    VARCHAR (100) CONSTRAINT [DF__TipoServi__Descr__7F2BE32F] DEFAULT (NULL) NOT NULL,
    [FechaRegistro]  DATETIME      CONSTRAINT [DF__TipoServi__Fecha__00200768] DEFAULT (getdate()) NOT NULL,
    [Activo]         BIT           CONSTRAINT [DF__TipoServi__Activ__01142BA1] DEFAULT (NULL) NOT NULL,
    [IdServicio]     INT           CONSTRAINT [DF__TipoServi__IdSer__02084FDA] DEFAULT (NULL) NOT NULL,
    CONSTRAINT [PK__TipoServ__E29B3EA795238383] PRIMARY KEY CLUSTERED ([IdTipoServicio] ASC)
);

