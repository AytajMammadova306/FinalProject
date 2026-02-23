using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Franchise;
using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class FranchiseService:IFranchiseService
    {
        private readonly IFranchiseRepository _repository;
        private readonly IMapper _mapper;

        public FranchiseService(
            IFranchiseRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetFranchiseItemVM>> GetAllItemAsync(int page = 0, int take = 0)
        {
            IReadOnlyList<Franchise> franchises = await _repository.GetAll(
                includes: [nameof(Genre),"Movies","TvShows"],
                page: page,
                take: take)
                .ToListAsync();
            ICollection<GetFranchiseItemVM> franchiseVms = _mapper.Map<ICollection<GetFranchiseItemVM>>(franchises);
            return franchiseVms;
        }
        public async Task<GetFranchiseVM> GetByIdAsync(long id)
        {
            Franchise franchise = await _repository.GetByIdAsync(id,
                includes: ["Genre", "Movies", "TvShows"]);
            return _mapper.Map<GetFranchiseVM>(franchise);
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetAll().CountAsync();
        }
    }
}
