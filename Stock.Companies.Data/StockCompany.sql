IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Company] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(256) NOT NULL,
    [Exchange] varchar(256) NOT NULL,
    [Ticker] varchar(256) NOT NULL,
    [ISIN] varchar(12) NOT NULL,
    [WebSite] varchar(256) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Company_ISIN] ON [Company] ([ISIN]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211017103657_Created Company', N'5.0.11');
GO

COMMIT;
GO

