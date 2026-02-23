using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class MovieService:IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieService(
            IMovieRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper=mapper;
        }
        
        public async Task<ICollection<GetMovieItemVM>> GetAllItemAsync(int page = 0, int take = 0, int key=0)
        {
            IReadOnlyList<Movie> movies = await _repository.GetAll(
                includes: "MovieGenres.Genre",
                page: page,
                take: take
                )
                .ToListAsync();
            if (key== (int)SortType.Date)
            {
				movies = movies.OrderBy(m => m.ReleaseDate).ToList();
			}
            else
            {
				movies = movies.OrderBy(m => m.Name).ToList();
			}
                
            ICollection<GetMovieItemVM> movieVms = _mapper.Map<ICollection<GetMovieItemVM>>(movies);
            return movieVms;
        }
        public async Task<GetMovieVM> GetByIdAsync(long id)
        {
            Movie movie = await _repository.GetByIdAsync(id,
                "Franchise",
                "MovieCasts.Actor",
                "MovieCrews.Crew",
                "MovieGenres.Genre",
                "MovieTags.Tag");
            return _mapper.Map<GetMovieVM>(movie);
        }
        public async Task<ICollection<GetMovieItemVM>> GetByFranchiseAsync(long id)
        {
            IReadOnlyList<Movie> movies = await _repository.GetAll(
                func:(m=>m.FranchiseId==id),
                includes: "MovieGenres.Genre")
                .ToListAsync();
            
            ICollection<GetMovieItemVM> movieVms = _mapper.Map<ICollection<GetMovieItemVM>>(movies);
            return movieVms;
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetAll().CountAsync();
        }
        public async Task<ICollection<GetMovieAdminVM>> GetAllMovieVMs(int page=0, int take=0)
        {
            IReadOnlyList<Movie> movie = await _repository.GetAll(
                page: page,
                take: take).ToListAsync();
            ICollection<GetMovieAdminVM> adminVMs = _mapper.Map<ICollection<GetMovieAdminVM>>(movie);
            return adminVMs;
        }
    }
}
