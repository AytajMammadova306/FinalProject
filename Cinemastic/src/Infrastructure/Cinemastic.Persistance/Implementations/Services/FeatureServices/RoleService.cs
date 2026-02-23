using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class RoleService:IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task CreateRoles()
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = role.ToString()
                    };
                    await _roleManager.CreateAsync(identityRole);
                }
                
            }
            
        }
    }
}
