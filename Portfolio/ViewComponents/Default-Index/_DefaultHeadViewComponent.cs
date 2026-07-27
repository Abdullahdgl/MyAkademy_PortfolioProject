using Microsoft.AspNetCore.Mvc;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultHeadViewComponent : ViewComponent

	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
