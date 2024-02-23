CREATE PROCEDURE [dbo].[spBookings_Search]
	@lastName nvarchar(50),
	@startDate date
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [b].[Id], [b].[RoomId], [b].[GuestId], [b].[StartDate], [b].[EndDate],
		[b].[CheckedIn], [b].[TotalCost], [g].[FirstName], [g].[LastName],
		[r].[RoomNumber], [r].[RoomTypeId], [rt].[Title], [rt].[Description],
		[rt].[Price]
	FROM [dbo].[Bookings] AS b
	INNER JOIN [dbo].[Guests] AS g ON b.[GuestId] = g.[Id]
	INNER JOIN [dbo].[Rooms] AS r ON b.[RoomId] = r.[Id]
	INNER JOIN [dbo].[RoomTypes] AS rt ON r.[RoomTypeId] = rt.[Id]
	WHERE b.[StartDate] = @startDate AND g.[LastName] = @lastName;
END