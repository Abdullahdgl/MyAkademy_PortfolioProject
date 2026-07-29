using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entites;

namespace Portfolio.Controllers
{
	public class TestimonialController : Controller
	{

		private readonly AppDbContext _context;

		public TestimonialController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var testimonial = _context.Testimonials.ToList();
			return View(testimonial);
		}

		[HttpGet]
		public IActionResult CreatTestimonial()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatTestimonial(Testimonial testimonial)
		{
			_context.Testimonials.Add(testimonial);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateTestimonial(int id)
		{
			var testimonial = _context.Testimonials.Find(id);
			return View(testimonial);
		}

		[HttpPost]
		public IActionResult UpdateTestimonial(Testimonial testimonial)
		{
			_context.Testimonials.Update(testimonial);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteTestimonial(int id)
		{
			var project = _context.Testimonials.Find(id);
			_context.Remove(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
