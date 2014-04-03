CREATE TABLE [dbo].[Courses] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [OrganizationId] INT             NOT NULL,
    [UniversalId]    NVARCHAR (MAX)  NULL,
    [Name]           NVARCHAR (MAX)  NULL,
    [Number]         NVARCHAR (MAX)  NULL,
    [CreditHour]     DECIMAL (18, 2) NOT NULL,
    [ClockHour]      DECIMAL (18, 2) NOT NULL,
    [Description]    NVARCHAR (MAX)  NULL,
    [Created]        DATETIME        DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

