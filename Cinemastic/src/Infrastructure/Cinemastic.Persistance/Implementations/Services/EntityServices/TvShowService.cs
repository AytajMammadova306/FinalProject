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
        public async Task<ICollection<GetTvShowItemVM>> GetAllItemAsync(int page = 0, int take = 0)
        {
            IReadOnlyList<TvShow> shows = await _repository.GetAll(
                includes: ["TvShowGenres.Genre","Seasons"],
                page: page,
                take: take)
                .ToListAsync();
            ICollection<GetTvShowItemVM> showVMs = _mapper.Map<ICollection<GetTvShowItemVM>>(shows);
            return showVMs;
        }
        public async Task<GetTvShowVM> GetByIdAsync(long id)
        {
            TvShow tvShow= await _repository.GetByIdAsync(id,
                "Franchise",
                "TvShowCasts.Actor",
                "TvShowCrews.Crew",
                "TvShowGenres.Genre",
                "TvShowTags.Tag",
                "Seasons.Episodes");
            return _mapper.Map<GetTvShowVM>(tvShow);
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetAll().CountAsync();
        }
        public async Task<ICollection<GetTvShowItemVM>> GetByFranchiseAsync(long id)
        {
            IReadOnlyList<TvShow> shows = await _repository.GetAll(
                includes: ["TvShowGenres.Genre", "Seasons"],
                func:(s=>s.FranchiseId==id))
                .ToListAsync();
            ICollection<GetTvShowItemVM> showVMs = _mapper.Map<ICollection<GetTvShowItemVM>>(shows);
            return showVMs;
        }
    }
}
