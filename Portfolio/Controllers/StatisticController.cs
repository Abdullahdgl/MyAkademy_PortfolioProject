using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.Controllers
{
	public class StatisticController : Controller
	{
		private readonly AppDbContext context;

		public StatisticController(AppDbContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			ViewBag.v1 = context.Skills.Count();
			ViewBag.v2 = context.UserMessages.Count();
			ViewBag.v3 = context.UserMessages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = context.UserMessages.Where(x => x.IsRead == true).Count();

			return View();
		}
	}
}
