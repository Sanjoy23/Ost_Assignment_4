USE [Ostdb]
GO

/****** Object: Table [dbo].[Products] Script Date: 6/15/2025 4:05:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (200)   NOT NULL,
    [Quantity] INT             NULL,
    [Price]    NUMERIC (18, 2) NULL
);


