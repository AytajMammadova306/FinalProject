using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Slide;
using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class SlideService:ISlideService
    {
        private readonly ISlideRepository _repository;
        private readonly IMapper _mapper;

        public SlideService(
            ISlideRepository repository,
            IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }
        public async Task<ICollection<GetSlideVM>> GetAllItemAsync()
        {
            IReadOnlyList<Slide> slides =await _repository.GetAll(
                includes: [
                    "Movie.MovieGenres.Genre",
                    "Movie.MovieTags.Tag",
                    "Movie.MovieCasts.Actor",
                    "TvShow.TvShowGenres.Genre",
                    "TvShow.TvShowTags.Tag",
                    "TvShow.TvShowCasts.Actor"
                    ],
                sort:(s => s.Movie != null ? s.Movie.ReleaseDate : s.TvShow!.ReleaseDate),
                desc:true)
                .ToListAsync();
            ICollection<GetSlideVM> slideVMs = _mapper.Map<ICollection<GetSlideVM>>( slides );
            return slideVMs;
        }
    }
}
