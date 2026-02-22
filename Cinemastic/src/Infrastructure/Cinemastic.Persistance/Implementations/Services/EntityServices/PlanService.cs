using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Plan;
using Cinemastic.Domain.Entities;
using Cinemastic.Persistance.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class PlanService:IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public PlanService(
            IPlanRepository planRepository,
            IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<PlanVM>> GetAllPlanVMs()
        {
            ICollection<Plan> plans = await _planRepository.GetAll().ToListAsync();
            return _mapper.Map<ICollection<PlanVM>>(plans);
        }
    }
}
