﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppLibrary.Models
{
	public class RoomModel
	{
		public int Id { get; set; }
		public string RoomNumber { get; set; } = string.Empty;
		public int RoomTypeId { get; set; }
	}
}
