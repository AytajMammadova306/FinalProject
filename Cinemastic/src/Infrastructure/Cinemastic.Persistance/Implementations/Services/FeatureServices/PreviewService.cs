using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.MVC.ViewModel.Movie;
using Cinemastic.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class PreviewService:IPreviewService
    {
        private readonly AppDbContext _context;
        private readonly IMovieService _movieService;

        public PreviewService(
            AppDbContext context,
            IMovieService movieService)
        {
            _context = context;
            _movieService = movieService;
        }
        public async Task<PreviewPageVM> GetPreviewAsync()
        {
            Dictionary<string, string> settings = await _context.PreviewSettings.ToDictionaryAsync(s => s.Key, s => s.Value);
            ICollection<GetMovieItemVM> movieItemVMs = (await _movieService.GetAllItemAsync())
                .Where(cVM => cVM.ReleaseDate <= DateTime.UtcNow)
                .OrderByDescending(cVM => cVM.ReleaseDate)
                .Take(15)
                .ToList();

            return new PreviewPageVM { LatestMovies = movieItemVMs, Settings=settings };
        }

    }
}
