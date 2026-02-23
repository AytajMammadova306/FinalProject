using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class AdminMovieService:IAdminMovieService
    {
        private readonly IMovieService _movieService;

        public AdminMovieService(
            IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<GetMovieAdminPageVM> GetMovieVMsAdmin(int page=0,int take=0)
        {
            ICollection<GetMovieAdminVM> movies = await _movieService.GetAllMovieVMs();
            int totalCount = await _movieService.GetTotalCountAsync();
            GetMovieAdminPageVM getMovieAdminPageVM = new GetMovieAdminPageVM
            {
                Movies = movies,
                Take = take,
                CurrentPage = page,
                TotalPages = totalCount
            };
            return getMovieAdminPageVM;
        }
    }
}
