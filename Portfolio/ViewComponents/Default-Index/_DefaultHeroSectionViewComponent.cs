using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultHeroSectionViewComponent : ViewComponent
	{
		private readonly AppDbContext _context;

		public _DefaultHeroSectionViewComponent(AppDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var abaout = _context.Banners.FirstOrDefault();
			return View(abaout);
		}
	}
}
