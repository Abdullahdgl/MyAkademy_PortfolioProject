using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class SkillController : Controller
	{
		private readonly AppDbContext _context;

		public SkillController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var skils = _context.Skills.ToList();
			return View(skils);
		}

		[HttpGet]
		public IActionResult CreatSkill()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatSkill(Skill skill)
		{
			_context.Skills.Add(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateSkill(int id)
		{
			var skil = _context.Skills.Find(id);
			return View(skil);
		}

		[HttpPost]
		public ActionResult UpdateSkill(Skill skill)
		{
			_context.Skills.Update(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteSkill(int id)
		{
			var project = _context.Skills.Find(id);
			_context.Remove(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
