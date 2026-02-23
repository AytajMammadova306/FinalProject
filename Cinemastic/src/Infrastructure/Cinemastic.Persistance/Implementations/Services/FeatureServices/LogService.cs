using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Account;
using Cinemastic.Domain.Entities;
using Cinemastic.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class LogService:ILogService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppDbContext _context;

        public LogService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IHttpContextAccessor httpContext,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
            _context = context;
        }
        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> LogInAsync(LogInVM userVM, ModelStateDictionary ModelState)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userVM.UserNameOrEmail);
            if(user is null)
            {
                ModelState.AddModelError(string.Empty, "Username, Eail or Password is incorrect");
                return false;
            }
            var result=await _signInManager.PasswordSignInAsync(user, userVM.Password, userVM.IsPersistance, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username, Eail or Password is incorrect");
                return false;
            }
            return true;
        }
        public async Task<InPageLogedInVM> GetLogedInVM()
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            InPageLogedInVM inPageLogedInVM = new InPageLogedInVM
            {
                Id = dbUser.Id,
                Name = dbUser.Name,
                Surname = dbUser.Surname,
                ImageUrl = dbUser.ImageUrl,

            };
            return inPageLogedInVM;
        }
    }
}
