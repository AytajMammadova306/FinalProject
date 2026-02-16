using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class TvShowService:ITvShowService
    {
        private readonly ITvShowRepository _repository;
        private readonly IMapper _mapper;

        public TvShowService(
            ITvShowRepository tvShowRepository,
            IMapper mapper)
        {
            _repository = tvShowRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetTvShowItemVM>> GetAllItemAsync()
        {
            IReadOnlyList<TvShow> shows = await _repository.GetAll(
                includes: ["TvShowGenres.Genre","Seasons"])
                .ToListAsync();
            ICollection<GetTvShowItemVM> showVMs = _mapper.Map<ICollection<GetTvShowItemVM>>(shows);
            return showVMs;
        }
    }
}
