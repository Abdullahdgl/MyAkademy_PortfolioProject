using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class ServiceController : Controller
	{

		private readonly AppDbContext _context;

		public ServiceController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var service = _context.Services.ToList();
			return View(service);
		}


		[HttpGet]
		public IActionResult CreatService()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatService(Service service)
		{
			_context.Services.Add(service);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateService(int id)
		{
			var service = _context.Services.Find(id);
			return View(service);
		}

		[HttpPost]
		public IActionResult UpdateService(Service service)
		{
			_context.Services.Update(service);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteService(int id)
		{
			var project = _context.Services.Find(id);
			_context.Remove(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
