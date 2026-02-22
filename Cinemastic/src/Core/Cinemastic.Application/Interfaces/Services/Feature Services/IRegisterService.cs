using Cinemastic.Application.ViewModel.Account;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface IRegisterService
    {
        Task<bool> RegisterUserAsync(RegisterVM registerVM, ModelStateDictionary ModelState);
    }
}
