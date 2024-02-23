CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Bookings]
	SET [CheckedIn] = 1
	WHERE [Id] = @Id;
END
