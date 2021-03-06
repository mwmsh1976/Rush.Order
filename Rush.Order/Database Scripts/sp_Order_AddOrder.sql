USE [Rush.Order]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddOrder]    Script Date: 9/22/2021 6:45:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_AddOrder]
       @CustomerId bigint,
	   @OrderNumber varchar(16) = '',
	   @Total decimal(10,2) = 0,
	   @Status varchar(16) = 'Pending'
AS
BEGIN

	DECLARE @NewRecordId bigint = 0;

    SET NOCOUNT ON;

    INSERT INTO [dbo].[Order]
            (CustomerId,OrderNumber,Total,Status)
    VALUES
            (@CustomerId,@OrderNumber,@Total,@Status)

	SELECT @NewRecordId = @@IDENTITY

	SELECT * FROM [dbo].[Order] WHERE Id = @NewRecordId;
END