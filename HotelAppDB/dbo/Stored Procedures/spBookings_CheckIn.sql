﻿CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Bookings]
	SET [CheckedIn] = 1
	WHERE [Id] = @Id;
END
