
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/05/2018 13:20:24
-- Generated from EDMX file: C:\Users\g.he\Documents\CSharp\Git\LinqFunctions\MVCFunctions\Models\UserInfoDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LinqFunctionsDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfoSet'
CREATE TABLE [dbo].[UserInfoSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UserAge] nvarchar(max)  NOT NULL,
    [ClassInfoClassId] int  NOT NULL
);
GO

-- Creating table 'OrderInfo'
CREATE TABLE [dbo].[OrderInfo] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [OrderName] nvarchar(max)  NOT NULL,
    [UserInfoUserId] int  NOT NULL
);
GO

-- Creating table 'ClassInfo'
CREATE TABLE [dbo].[ClassInfo] (
    [ClassId] int IDENTITY(1,1) NOT NULL,
    [ClassName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserInfoSet'
ALTER TABLE [dbo].[UserInfoSet]
ADD CONSTRAINT [PK_UserInfoSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [OrderId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [PK_OrderInfo]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [ClassId] in table 'ClassInfo'
ALTER TABLE [dbo].[ClassInfo]
ADD CONSTRAINT [PK_ClassInfo]
    PRIMARY KEY CLUSTERED ([ClassId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfoUserId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [FK_UserInfoOrderInfo]
    FOREIGN KEY ([UserInfoUserId])
    REFERENCES [dbo].[UserInfoSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoOrderInfo'
CREATE INDEX [IX_FK_UserInfoOrderInfo]
ON [dbo].[OrderInfo]
    ([UserInfoUserId]);
GO

-- Creating foreign key on [ClassInfoClassId] in table 'UserInfoSet'
ALTER TABLE [dbo].[UserInfoSet]
ADD CONSTRAINT [FK_ClassInfoUserInfo]
    FOREIGN KEY ([ClassInfoClassId])
    REFERENCES [dbo].[ClassInfo]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassInfoUserInfo'
CREATE INDEX [IX_FK_ClassInfoUserInfo]
ON [dbo].[UserInfoSet]
    ([ClassInfoClassId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------