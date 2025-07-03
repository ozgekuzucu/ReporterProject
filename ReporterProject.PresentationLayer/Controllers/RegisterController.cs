using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReporterProject.EntityLayer.Entities;
using ReporterProject.PresentationLayer.Models;

namespace ReporterProject.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult CreateUser()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser(UserRegisterViewModel model)
		{
			AppUser appUser = new AppUser()
			{
				Name = model.Name,
				Surname = model.Surname,
				Email = model.Email,
				UserName = model.Username,
				ImageUrl ="test",
				Description ="test"
			};
			await _userManager.CreateAsync(appUser, model.Password);
			return RedirectToAction("UserLogin", "Login");
		}
	}
}
