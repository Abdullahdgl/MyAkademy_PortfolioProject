using Microsoft.AspNetCore.Mvc;

namespace Portfolio.ViewComponents.AdminLayout
{
	public class _AdminTopNavbarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}
