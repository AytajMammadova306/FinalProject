using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinemastic.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly ILogService _logService;
        private readonly IRoleService _roleService;

        public AccountController(
            IRegisterService registerService,
            ILogService logService,
            IRoleService roleService)
        {
            _registerService = registerService;
            _logService = logService;
            _roleService = roleService;
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
        public async Task<IActionResult> LogOut()
        {
            await _logService.LogOutAsync();
            return RedirectToAction("Preview", "Home");
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM logInVM)
        {
            if(!ModelState.IsValid) return View();
            bool result = await _logService.LogInAsync(logInVM,ModelState);
            if(!result) return View();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CreateRoles()
        {
            await _roleService.CreateRoles();
            return RedirectToAction("Index", "Home");
        }
    }
}
