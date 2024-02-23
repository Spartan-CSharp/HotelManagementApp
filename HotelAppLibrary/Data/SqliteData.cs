using System;
using System.Collections.Generic;
using System.Text;

using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
	public class SqliteData : IDatabaseData
	{
		private const string connectionStringName = "SqliteDb";
		private readonly ISqliteDataAccess _db;

		public SqliteData(ISqliteDataAccess db)
		{
			_db = db;
		}

		public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
		{
			throw new NotImplementedException();
		}

		public void CheckInGuest(int bookingId)
		{
			throw new NotImplementedException();
		}

		public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
		{
			string sql = @"SELECT t.[Id], t.[Title], t.[Description], t.[Price]
						FROM [Rooms] AS r
						INNER JOIN [RoomTypes] AS t ON t.[Id] = r.[RoomTypeId]
						WHERE r.[Id] NOT IN (
						SELECT b.[RoomId]
						FROM [Bookings] AS b
						WHERE (@startDate < b.[StartDate] AND @endDate > b.[EndDate])
							OR (b.[StartDate] <= @endDate AND @endDate < b.[EndDate])
							OR (b.[StartDate] <= @startDate AND @startDate < b.[EndDate])
						)
						GROUP BY t.[Id], t.[Title], t.[Description], t.[Price];";

			var output = _db.LoadData<RoomTypeModel, dynamic>(sql,
									  new { startDate, endDate },
									  connectionStringName);

			output.ForEach(x => x.Price = x.Price / 100);

			return output;
		}

		public RoomTypeModel GetRoomTypeById(int id)
		{
			throw new NotImplementedException();
		}

		public List<BookingFullModel> SearchBookings(string lastName)
		{
			throw new NotImplementedException();
		}
	}
}
