CREATE TABLE [dbo].[Organizations] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Campus]   NVARCHAR (MAX) NULL,
    [Address1] NVARCHAR (MAX) NULL,
    [Address2] NVARCHAR (MAX) NULL,
    [City]     NVARCHAR (MAX) NULL,
    [State]    NVARCHAR (MAX) NULL,
    [ZipCode]  NVARCHAR (MAX) NULL,
    [Country]  NVARCHAR (MAX) NULL,
    [OPEID]    NVARCHAR (MAX) NULL,
    [Created]  DATETIME       DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_dbo.Organizations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

