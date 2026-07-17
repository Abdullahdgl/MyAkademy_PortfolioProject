using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultContectInfoViewComponent : ViewComponent
	{
		private readonly AppDbContext _context;

		public _DefaultContectInfoViewComponent(AppDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{

			var contectInfo = _context.ContactInfos.ToList();


			return View(contectInfo);
		}
	}
}
