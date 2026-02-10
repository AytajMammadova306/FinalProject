using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Domain.Entities;
using Cinemastic.MVC.ViewModel.Movie;
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
        
        public async Task<ICollection<GetMovieItemVM>> GetAllAsync()
        {
            IReadOnlyList<Movie> movies = await _repository.GetAll(
                includes: "MovieGenres.Genre")
                .ToListAsync();
            ICollection<GetMovieItemVM> movieVms = _mapper.Map<ICollection<GetMovieItemVM>>(movies);
            return movieVms;
        }
    }
}
