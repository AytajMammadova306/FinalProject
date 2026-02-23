using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Featured;
using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class GenreService:IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(
            IGenreRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GenreCardVM>> GetMovieGenreCardVMs()
        {
            IReadOnlyList<Genre> genres = await _repository.GetAll(func:(g=>g.MovieGenres.Count()>0)).ToListAsync();
            return _mapper.Map<ICollection<GenreCardVM>>(genres);
        }
        public async Task<ICollection<GenreCardVM>> GetTvShowGenreCardVMs()
        {
            IReadOnlyList<Genre> genres = await _repository.GetAll(func: (g => g.TvShowGenres.Count() > 0)).ToListAsync();
            return _mapper.Map<ICollection<GenreCardVM>>(genres);
        }
    }
}
