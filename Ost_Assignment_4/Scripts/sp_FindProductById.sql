USE [Ostdb]
GO

/****** Object: SqlProcedure [dbo].[sp_FindProductById] Script Date: 6/15/2025 4:07:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_FindProductById]
	@id int
AS
BEGIN
	Select * from Products where Id = @id
END
