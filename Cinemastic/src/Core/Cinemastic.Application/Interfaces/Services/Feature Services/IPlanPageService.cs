using Cinemastic.Application.ViewModel.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface IPlanPageService
    {
        Task<PlanPageVM> GetPlanPageVM();
    }
}
