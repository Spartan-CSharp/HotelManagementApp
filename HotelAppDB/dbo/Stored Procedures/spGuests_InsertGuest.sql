CREATE PROCEDURE [dbo].[spGuests_InsertGuest]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM [dbo].[Guests] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	BEGIN
		INSERT INTO [dbo].[Guests] ([FirstName], [LastName])
		VALUES (@firstName, @lastName);
	END

	SELECT TOP 1 [Id], [FirstName], [LastName]
	FROM [dbo].[Guests]
	WHERE [FirstName] = @firstName AND [LastName] = @lastName;
END
