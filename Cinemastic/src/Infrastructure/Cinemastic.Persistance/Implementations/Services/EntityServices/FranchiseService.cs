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
        public async Task<ICollection<GetFranchiseItemVM>> GetAllItemAsync()
        {
            IReadOnlyList<Franchise> franchises = await _repository.GetAll(
                includes: [nameof(Genre),"Movies","TvShows"])
                .ToListAsync();
            ICollection<GetFranchiseItemVM> franchiseVms = _mapper.Map<ICollection<GetFranchiseItemVM>>(franchises);
            return franchiseVms;
        }

    }
}
