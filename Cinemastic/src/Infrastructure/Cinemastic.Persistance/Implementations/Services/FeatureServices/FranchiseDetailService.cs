using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Franchise;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Application.ViewModel.TvShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    public class FranchiseDetailService:IFranchiseDetailService
    {
        private readonly IFranchiseService _service;
        private readonly IMovieService _movieService;
        private readonly ITvShowService _tvShowService;

        public FranchiseDetailService(
            IFranchiseService service,
            IMovieService movieService,
            ITvShowService tvShowService)
        {
            _service = service;
            _movieService = movieService;
            _tvShowService = tvShowService;
        }
        public async Task<FranchiseDetailPageVM> GetFranchiseDetailPageVM(long id)
        {
            GetFranchiseVM franchiseVM = await _service.GetByIdAsync(id);
            ICollection<GetMovieItemVM>movies =await _movieService.GetByFranchiseAsync(id);
            ICollection<GetTvShowItemVM> tvShows = await _tvShowService.GetByFranchiseAsync(id);
            FranchiseDetailPageVM franchiseDetailPageVM = new FranchiseDetailPageVM
            {
                FranchiseVM=franchiseVM,
                Movies=movies,
                TvShows=tvShows
            };
            return franchiseDetailPageVM;
        }
    }
}
