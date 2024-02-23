﻿CREATE PROCEDURE [dbo].[spRoomTypes_GetById]
	@id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Title], [Description], [Price]
	FROM [dbo].[RoomTypes]
	WHERE [Id] = @id;
END