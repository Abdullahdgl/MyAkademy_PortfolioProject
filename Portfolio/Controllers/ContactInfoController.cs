using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class ContactInfoController : Controller
	{
		private readonly AppDbContext _context;

		public ContactInfoController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var contact = _context.ContactInfos.Find(1);
			return View(contact);
		}

		[HttpPost]
		public IActionResult Index(ContactInfo contactInfo)
		{
			_context.ContactInfos.Update(contactInfo);

			int sonuc = _context.SaveChanges();

			if (sonuc > 0)
			{
				ViewBag.Durum = "İletişim Bilgiler başarıyla güncellendi.";
			}
			else
			{
				ViewBag.Durum = "Güncelleme sırasında bir değişiklik yapılmadı.";
			}

			return View();
		}
	}
}
