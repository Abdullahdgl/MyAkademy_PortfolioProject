using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class BannerController : Controller
	{

		private readonly AppDbContext _context;

		public BannerController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var banners = _context.Banners.ToList();
			return View(banners);
		}

		[HttpGet]
		public IActionResult CreatBanner()
		{
			return View();

		}

		[HttpPost]
		public IActionResult CreatBanner(Banner banner)
		{
			_context.Banners.Add(banner);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}


		[HttpGet]
		public IActionResult UpdateBanner(int id)
		{
			var banner = _context.Banners.Find(id);
			return View(banner);
		}


		[HttpPost]
		public IActionResult UpdateBanner(Banner banner)
		{
			_context.Update(banner);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}


		public IActionResult DeleteBanner(int id)
		{
			var banner = _context.Banners.Find(id);
			_context.Remove(banner);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}

	}
}
