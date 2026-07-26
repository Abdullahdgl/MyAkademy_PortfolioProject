using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultEducationViewComponent : ViewComponent
	{
		private readonly AppDbContext _appDbContext;

		public _DefaultEducationViewComponent(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IViewComponentResult Invoke()
		{
			var values = _appDbContext.Educations.ToList();
			return View(values);
		}


	}
}
