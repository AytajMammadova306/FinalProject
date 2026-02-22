using AutoMapper;
using Cinemastic.Application.ViewModel.Plan;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class PlanProfile:Profile
    {
        public PlanProfile()
        {
            CreateMap<Plan, PlanVM>()
            .ForMember(dest => dest.Interval, opt => opt.MapFrom(src =>
                src.Interval.ToString()));
        }
    }
}
