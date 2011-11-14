
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2011 04:10:05
-- Generated from EDMX file: C:\projects\geakets_dot_net\Geakets\Models\Entities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Geakets];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Geakets_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Geakets] DROP CONSTRAINT [FK_Geakets_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_GeaketsChildren_Geakets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Geakets] DROP CONSTRAINT [FK_GeaketsChildren_Geakets];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Geakets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Geakets];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Geakets'
CREATE TABLE [dbo].[Geakets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ParentId] int  NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [ViewCount] int  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [CreatedAt] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Email] varchar(255)  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [CreatedAt] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Geakets'
ALTER TABLE [dbo].[Geakets]
ADD CONSTRAINT [PK_Geakets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Geakets'
ALTER TABLE [dbo].[Geakets]
ADD CONSTRAINT [FK_Geakets_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Geakets_Users'
CREATE INDEX [IX_FK_Geakets_Users]
ON [dbo].[Geakets]
    ([UserId]);
GO

-- Creating foreign key on [ParentId] in table 'Geakets'
ALTER TABLE [dbo].[Geakets]
ADD CONSTRAINT [FK_GeaketsChildren_Geakets]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[Geakets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GeaketsChildren_Geakets'
CREATE INDEX [IX_FK_GeaketsChildren_Geakets]
ON [dbo].[Geakets]
    ([ParentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------