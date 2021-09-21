CREATE PROCEDURE sp_AddOrder
       @CustomerId bigint,
	   @OrderNumber varchar(16) = NULL,
	   @Total decimal(10,2) = NULL,
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