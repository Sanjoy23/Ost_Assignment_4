USE [Ostdb]
GO

/****** Object: SqlProcedure [dbo].[sp_InsertProduct] Script Date: 6/15/2025 4:06:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_InsertProduct]
	@Name nvarchar(200),
	@Quantity int,
	@Price decimal(18,2)
AS
BEGIN
	INSERT INTO Products (Name, Quantity, Price) VALUES (@Name, @Quantity, @Price);
	SELECT CAST(SCOPE_IDENTITY() as int)
END
