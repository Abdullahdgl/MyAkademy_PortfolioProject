using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultExperienceViewComponent : ViewComponent
	{
		private readonly AppDbContext _appDbContext;

		public _DefaultExperienceViewComponent(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IViewComponentResult Invoke()
		{
			var values = _appDbContext.experiences.ToList();
			return View(values);
		}


	}
}
