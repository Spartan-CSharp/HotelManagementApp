﻿using System;
using System.Collections.Generic;
using System.Text;

using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
	public class SqlData
	{
		private readonly ISqlDataAccess _db;
		private const string connectionStringName = "SqlDb";

		public SqlData(ISqlDataAccess db)
		{
			_db = db;
		}

		public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
		{
			return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
									  new { startDate, endDate },
									  connectionStringName,
									  true);
		}
	}
}
