using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Plan;
using Cinemastic.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class PlanPageService:IPlanPageService
    {
        private readonly AppDbContext _context;
        private readonly IPlanService _planService;

        public PlanPageService(
            IPlanService planService,
            AppDbContext context)
        {
            _context = context;
            _planService = planService;
        }
        public async Task<PlanPageVM> GetPlanPageVM()
        {
            PlanPageVM planPageVM = new PlanPageVM
            {
                PlanVMs = await _planService.GetAllPlanVMs(),
                BackGround = (await _context.PreviewSettings.FirstOrDefaultAsync(s => s.Key.ToLower().Equals("background"))).Value
            };
            return planPageVM;
        }
    }
}
