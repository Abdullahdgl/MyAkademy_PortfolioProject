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

		public IActionResult Index()
		{
			var value = _context.ContactInfos.FirstOrDefault();
			return View(value);
		}

		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateContactInfo(ContactInfo contactInfo)
		{
			_context.ContactInfos.Add(contactInfo);
			_context.SaveChanges();
			return RedirectToAction("Index", "ContactInfo");
		}

		[HttpGet]
		public IActionResult UpdateContactInfo(int id)
		{
			var value = _context.ContactInfos.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateContactInfo(ContactInfo contactInfo)
		{
			_context.ContactInfos.Update(contactInfo);
			_context.SaveChanges();
			return RedirectToAction("Index", "ContactInfo");
		}

		public IActionResult DeleteContactInfo(int id)
		{
			var value = _context.ContactInfos.Find(id);
			_context.ContactInfos.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("Index", "ContactInfo");
		}
	}
}
