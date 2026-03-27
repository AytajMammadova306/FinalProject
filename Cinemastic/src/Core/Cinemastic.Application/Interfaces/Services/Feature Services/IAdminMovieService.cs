using Cinemastic.Application.ViewModel.Movie;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface IAdminMovieService
    {
        Task<GetMovieAdminPageVM> GetMovieVMsAdmin(int page = 0, int take = 0);
        Task<CreateMovieVM> CreateGetMovieAsync();
        Task<bool> CreatePostMovieAsync(CreateMovieVM movieVM, ModelStateDictionary model);
    }
}
