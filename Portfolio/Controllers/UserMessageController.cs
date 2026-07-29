using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.Controllers
{
	public class UserMessageController : Controller
	{
		private readonly AppDbContext _context;

		public UserMessageController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var messages = _context.UserMessages.ToList();
			return View(messages);
		}

		[HttpGet]
		public IActionResult UserMessageDetail(int id)
		{
			var message = _context.UserMessages.Find(id);


			// Okundu olarak işaretle
			message.IsRead = true;
			_context.SaveChanges();

			return View(message);
		}
	}
}
