using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class ProjectTechStacksController : Controller
	{
		private readonly AppDbContext _context;

		public ProjectTechStacksController(AppDbContext context)
		{
			_context = context;
		}

		//eager loading:Herşeyi tek seferde getirmek için kullanılır. yani birden fazla tabloyu tek seferde getirmek için kullanılır. lazy loading: sadece ihtiyacımız olan veriyi getirmek için kullanılır. yani bir tabloyu getirmek için kullanılır. explicit loading: sadece ihtiyacımız olan veriyi getirmek için kullanılır. yani bir tabloyu getirmek için kullanılır. SQL deki inner join gibi düşünebiliriz. yani bir tabloyu getirmek için kullanılır.
		public IActionResult Index()
		{
			var projectTechStacks = _context.ProjectTechStacks
				.Include(x => x.Project)
				.Include(y => y.TechStack).ToList();

			return View(projectTechStacks);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var projects = _context.Projects.ToList();
			var techStacks = _context.TechStacks.ToList();
			ViewBag.projects = (from project in projects
								select new SelectListItem
								{
									Text = project.Name,
									Value = project.Id.ToString()	
								}).ToList();

			ViewBag.techStacks = (from techStack in techStacks
								  select new SelectListItem
								  {
									  Text = techStack.Name,
									  Value = techStack.Id.ToString()
								  }).ToList();

			return View();
		}
		[HttpPost]
		public IActionResult Create(ProjectTechStack projectTechStack)
		{
		
			_context.ProjectTechStacks.Add(projectTechStack);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
