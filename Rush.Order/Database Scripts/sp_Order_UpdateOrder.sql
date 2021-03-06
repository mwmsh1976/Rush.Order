USE [Rush.Order]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateOrder]    Script Date: 9/22/2021 7:34:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UpdateOrder]
	   @Id bigint,
	   @Total decimal(10,2),
	   @Status varchar(16)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE [dbo].[Order]
    SET Total = @Total, [Status] = @Status
	WHERE Id = @Id;

	SELECT * FROM [dbo].[Order] WHERE Id = @Id;

END