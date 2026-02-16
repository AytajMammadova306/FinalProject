using AutoMapper;
using Cinemastic.Application.ViewModel.Franchise;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class FranchiseProfile:Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, GetFranchiseItemVM>()
            .ForMember(fVM => fVM.Genre,
                opt => opt.MapFrom(f => f.Genre.Name))

            .ForMember(fVM => fVM.ContentCount,
                opt => opt.MapFrom(f =>
                    (f.Movies != null ? f.Movies.Count : 0) +
                    (f.TvShows != null ? f.TvShows.Count : 0)
                ));
        }
    }
}
