using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultPortfolioViewComponent : ViewComponent
	{

		private readonly AppDbContext _context;

		public _DefaultPortfolioViewComponent(AppDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{

			var contectInfo = _context.Projects.Include(X=>X.ProjectTechStacks).ThenInclude(X=>X.TechStack).ToList();

			return View(contectInfo);
		}

	}
}
