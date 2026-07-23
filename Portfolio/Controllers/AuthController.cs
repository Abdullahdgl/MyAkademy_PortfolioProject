using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Models;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
	[AllowAnonymous]
	public class AuthController : Controller
	{
		private readonly AppDbContext _context;

		public AuthController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			var admin = _context.Admins.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

			if(!ModelState.IsValid)
				{
				return View(model);
			}

			if (admin == null)
			{
				ModelState.AddModelError(string.Empty, "Kullanıcı adi veya Şifre hatalı!");
				return View(model);
			}
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name,admin.UserName),
				new Claim("FullName",admin.FullName)
			};

			var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

			var authPropt = new AuthenticationProperties
			{
				ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
				IsPersistent = false
			};

			//cookie ile giriş yapma işlemi yazdırdım. 
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),authPropt);

			HttpContext.Session.SetString("FullName", admin.FullName);

			return RedirectToAction("Index","About");

		}

		public async Task<IActionResult> Logout()
		{
			HttpContext.Session.Remove("FullName");
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Default");
		}


	}
}
