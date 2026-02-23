using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Account;
using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class RegisterService:IRegisterService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public RegisterService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }
        public async Task<bool> RegisterUserAsync(RegisterVM userVM, ModelStateDictionary ModelState)
        {
            AppUser user = new AppUser
            {
                UserName = userVM.UserName,
                Email = userVM.Email,
                Name = char.ToUpper(userVM.Name[0]) + userVM.Name[1..],
                Surname = char.ToUpper(userVM.Surname[0]) + userVM.Surname[1..],
                ImageUrl=_config["CloudinarySettings:DefaultAvatarUrl"]
            };
            IdentityResult result = await _userManager.CreateAsync(user,userVM.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return false;
            }
            await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());
            await _signInManager.SignInAsync(user, isPersistent: false);

            return true;
        }
    }
}
