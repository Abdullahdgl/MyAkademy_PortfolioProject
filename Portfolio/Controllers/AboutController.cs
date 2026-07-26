using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{

	public class AboutController : Controller
	{


		private readonly AppDbContext _context;


		public AboutController(AppDbContext context)
		{
			_context = context;
		}

		//sadece bu sınıf üzerinden erişilebilen bir fieldir. yani controller sınıfından bir index sayfası ayağı kalktığı zaman  biz bir constractot oluşturup burası otomatik olarak ayağı kaldırmak isteteceğimiz bir alandır. aslında constractor oluştumamızdaki mahiyet.



		public IActionResult Index() 
			// index içerisindeki bizim amacımız neydi verileri listelemek/getirmek.
		{
			var about = _context.Abouts.FirstOrDefault(); // burdaki ilk veriyi yani tek bir değer getirmek isteriz.
			return View(about);
		}

		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateAbout(About about)
		{
		 	_context.Abouts.Add(about);
			int result = _context.SaveChanges();
			if(result>0)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError("", "About eklenirken bir hata oluştu.");
				return View(about);
			}

		}

		public IActionResult UpdateAbout(int id)
		{
			var about = _context.Abouts.Find(id);
			return View(about);
		}

		[HttpPost]
		public IActionResult UpdateAbout(About about)
		{
			_context.Abouts.Update(about);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}

		public IActionResult DeleteAbout(int id)
		{
			var about = _context.Abouts.Find(id);
			_context.Abouts.Remove(about);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}


	}

}
