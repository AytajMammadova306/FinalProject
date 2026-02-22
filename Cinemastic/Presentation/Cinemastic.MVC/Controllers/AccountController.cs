using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace Cinemastic.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterService _registerService;

        public AccountController(
            IRegisterService registerService)
        {
            _registerService = registerService;   
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM userVM)
        {
            if (!ModelState.IsValid) return View();
            bool result =await _registerService.RegisterUserAsync(userVM, ModelState);
            if (!result) return View();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
