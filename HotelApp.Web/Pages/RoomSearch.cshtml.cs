using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using HotelAppLibrary.Data;
using HotelAppLibrary.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelApp.Web.Pages
{
	public class RoomSearchModel : PageModel
	{
		private readonly ILogger<RoomSearchModel> _logger;
		private readonly IDatabaseData _db;

		[DataType(DataType.Date)]
		[BindProperty(SupportsGet = true)]
		public DateTime StartDate { get; set; } = DateTime.Now;

		[DataType(DataType.Date)]
		[BindProperty(SupportsGet = true)]
		public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

		[BindProperty(SupportsGet = true)]
		public bool SearchEnabled { get; set; } = false;

		public List<RoomTypeModel> AvailableRoomTypes { get; set; }

		public RoomSearchModel(ILogger<RoomSearchModel> logger, IDatabaseData db)
		{
			_logger = logger;
			_db = db;
		}

		public void OnGet()
		{
			_logger.LogInformation("OnGet RoomSearch Page with SearchEnabled = {SearchEnabled}", SearchEnabled);
			if ( SearchEnabled == true )
			{
				AvailableRoomTypes = _db.GetAvailableRoomTypes(StartDate, EndDate);
			}
		}

		public IActionResult OnPost()
		{
			_logger.LogInformation("OnPost RoomSearch Page with SearchEnabled = {SearchEnabled}, StartDate = {StartDate}, EndDate = {EndDate}", SearchEnabled, StartDate, EndDate);
			return RedirectToPage(new
			{
				SearchEnabled = true,
				StartDate = StartDate.ToString("yyyy-MM-dd"),
				EndDate = EndDate.ToString("yyyy-MM-dd")
			});
		}
	}
}
