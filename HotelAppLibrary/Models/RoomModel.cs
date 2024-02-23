namespace HotelAppLibrary.Models
{
	public class RoomModel
	{
		public int Id { get; set; }
		public string RoomNumber { get; set; } = string.Empty;
		public int RoomTypeId { get; set; }
	}
}
