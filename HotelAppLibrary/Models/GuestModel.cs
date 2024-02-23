using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppLibrary.Models
{
	public class GuestModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
	}
}
