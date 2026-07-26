using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class ExperienceController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public ExperienceController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IActionResult Index()
		{
			var values = _appDbContext.experiences.ToList();
			return View(values);
		}


		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Experience experience)
		{
			_appDbContext.experiences.Add(experience);
			_appDbContext.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var value = _appDbContext.experiences.Find(id);
			_appDbContext.experiences.Remove(value);
			_appDbContext.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(int id)
		{
			var value = _appDbContext.experiences.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult Update(Experience experience)
		{
			_appDbContext.experiences.Update(experience);
			_appDbContext.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
