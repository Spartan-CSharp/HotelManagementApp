using System;

using HotelAppLibrary.Data;
using HotelAppLibrary.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelApp.Web.Pages
{
	public class BookRoomModel : PageModel
	{
		private readonly ILogger<BookRoomModel> _logger;
		private readonly IDatabaseData _db;

		[BindProperty(SupportsGet = true)]
		public int RoomTypeId { get; set; }

		[BindProperty(SupportsGet = true)]
		public DateTime StartDate { get; set; }

		[BindProperty(SupportsGet = true)]
		public DateTime EndDate { get; set; }

		[BindProperty]
		public string FirstName { get; set; }

		[BindProperty]
		public string LastName { get; set; }

		public RoomTypeModel RoomType { get; set; }

		public BookRoomModel(ILogger<BookRoomModel> logger, IDatabaseData db)
		{
			_logger = logger;
			_db = db;
		}

		public void OnGet()
		{
			_logger.LogInformation("OnGet BookRoom Page with RoomTypeId = {RoomTypeId}", RoomTypeId);
			if ( RoomTypeId > 0 )
			{
				RoomType = _db.GetRoomTypeById(RoomTypeId);
			}
		}

		public IActionResult OnPost()
		{
			_logger.LogInformation("OnPost BookRoom Page with RoomTypeId = {RoomTypeId}, FirstName = {FirstName}, LastName = {LastName}, StartDate = {StartDate}, EndDate = {EndDate}", RoomTypeId, FirstName, LastName, StartDate, EndDate);
			_db.BookGuest(FirstName, LastName, StartDate, EndDate, RoomTypeId);
			return RedirectToPage("/Index");
		}
	}
}
