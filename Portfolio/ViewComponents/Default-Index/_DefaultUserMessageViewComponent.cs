using Microsoft.AspNetCore.Mvc;
using Portfolio.ViewComponents.Default_Index;

namespace Portfolio.ViewComponents.Default_Index
{
	public class _DefaultUserMessageViewComponent: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
