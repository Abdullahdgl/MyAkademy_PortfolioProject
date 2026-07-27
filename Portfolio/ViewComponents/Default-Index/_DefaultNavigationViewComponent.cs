using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultNavigationViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		}
	}
}
