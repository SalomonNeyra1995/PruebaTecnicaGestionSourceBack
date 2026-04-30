CREATE TABLE [dbo].[Casas] (
    [Id]                   INT              IDENTITY (1, 1) NOT NULL,
    [Direccion]            NVARCHAR (200)   NOT NULL,
    [Distrito]             NVARCHAR (100)   NOT NULL,
    [NumeroHabitaciones]   INT              NOT NULL,
    [TipoCasa]             NVARCHAR (50)    NOT NULL,
    [AreaMetrosCuadrados]  DECIMAL (10, 2)  NOT NULL,
    [Precio]               DECIMAL (18, 2)  NOT NULL,
    [FechaRegistro]        DATETIME2 (7)    NOT NULL,
    [EstaActivo]           BIT              NOT NULL,
    CONSTRAINT [PK_Casas] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE NONCLUSTERED INDEX [IX_Casas_Distrito] ON [dbo].[Casas]([Distrito] ASC);