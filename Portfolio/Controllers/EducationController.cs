using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class EducationController : Controller
	{
		private readonly AppDbContext _context;

		public EducationController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var education = _context.Educations.ToList();
			return View(education);
		}

		[HttpGet]
		public IActionResult CreatEducation()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatEducation(Education education)
		{
			_context.Add(education);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateEducation(int id)
		{
			var education = _context.Educations.Find(id);
			return View(education);
		}



		[HttpPost]
		public IActionResult UpdateEducation(Education education)
		{
			_context.Educations.Update(education);
			_context.SaveChanges(true);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteEducation(int id)
		{
			var project = _context.Educations.Find(id);
			_context.Remove(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
