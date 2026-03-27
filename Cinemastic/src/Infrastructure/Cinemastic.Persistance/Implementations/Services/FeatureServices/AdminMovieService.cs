using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        private readonly ITagService _tagService;
        private readonly IGenreService _genreService;
        private readonly IFranchiseService _franchiseService;
        private readonly ICrewService _crewService;
        private readonly IActorService _actorService;
        private readonly IFileService _fileService;

        public AdminMovieService(
            IMovieService movieService,
            ITagService tagService,
            IGenreService genreService,
            IFranchiseService franchiseService,
            ICrewService crewService,
            IActorService actorService,
            IFileService fileService)
        {
            _movieService = movieService;
            _tagService = tagService;
            _genreService = genreService;
            _franchiseService = franchiseService;
            _crewService = crewService;
            _actorService = actorService;
            _fileService = fileService;
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
        public async Task<CreateMovieVM> CreateGetMovieAsync()
        {
            CreateMovieVM createMovieVM = new CreateMovieVM
            {
                Tags = await _tagService.GetAllTagsAsync(),
                Genres = await _genreService.GetAllGenresAsync(),
                Franchises = await _franchiseService.GetAllFranchiseAsync(),
                Casts = await _actorService.GetAllActorsAsync(),
                Crews = await _crewService.GetAllCrewsAsync()
            };
            return createMovieVM;
        }
        public async Task<bool> CreatePostMovieAsync(CreateMovieVM movieVM,ModelStateDictionary model)
        {
            movieVM.Tags= await _tagService.GetAllTagsAsync();
            movieVM.Genres = await _genreService.GetAllGenresAsync();
            movieVM.Franchises = await _franchiseService.GetAllFranchiseAsync();
            movieVM.Casts = await _actorService.GetAllActorsAsync();
            movieVM.Crews = await _crewService.GetAllCrewsAsync();
            string message = string.Empty;
            if (movieVM.AgeRating is null)
            {
                return false;
            }
            if (movieVM.MovieCasts is null )
            {
                return false;
            }
            if (movieVM.MovieCrews is null)
            {
                return false;
            }
            if (movieVM.GenreIds.FirstOrDefault(gi => !movieVM.Genres.ToList().Exists(g => g.Id == gi)) ==0)
            {
                model.AddModelError(nameof(CreateMovieVM.GenreIds), "Genres are wrong");
                return false;
            }
            if (movieVM.TagIds.Any(ti => !movieVM.Tags.ToList().Exists(t => t.Id == ti)))
            {
                model.AddModelError(nameof(CreateMovieVM.TagIds), "Tags are wrong");
                return false;
            }
            if (!movieVM.Franchises.Any(f => f.Id == movieVM.FranchiseId))
            {
                model.AddModelError(nameof(CreateMovieVM.FranchiseId), "Franchise is wrong");
            }
            string imageUrl = (await _fileService.AddImageAsync(movieVM.ImageFile)).Url;
            string imageIublicId = (await _fileService.AddImageAsync(movieVM.ImageFile)).PublicId;
            string CoverUrl = (await _fileService.AddImageAsync(movieVM.CoverFile)).Url;
            string CoverpublicId = (await _fileService.AddImageAsync(movieVM.CoverFile)).PublicId;
            string VideoUrl = (await _fileService.AddImageAsync(movieVM.VideoFile)).Url;
            string VideoPublicId = (await _fileService.AddImageAsync(movieVM.VideoFile)).PublicId;
            


            return true;
            
        }
    }
}
