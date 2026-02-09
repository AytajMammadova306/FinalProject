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
        
        public async Task<ICollection<GetContentItemVM>> GetAllAsync()
        {
            IReadOnlyList<Movie> contents = await _repository.GetAll(
                includes: "ContentGenres.Genre")
                .ToListAsync();
            ICollection<GetContentItemVM> contentVms = _mapper.Map<ICollection<GetContentItemVM>>(contents);
            return contentVms;
        }
    }
}
