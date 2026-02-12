using AutoMapper;
using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class TvShowProfile:Profile
    {
        public TvShowProfile()
        {
            CreateMap<TvShow, GetTvShowItemVM>()
                .ForMember(tsVM => tsVM.Genres, opt => opt.MapFrom(ts =>
                    ts.TvShowGenres
                    .Select(tsg => tsg.Genre.Name)
                    .Take(2)
                    .ToList()))
                .ForMember(tsVM => tsVM.GenresCount, opt => opt.MapFrom(ts => ts.TvShowGenres.Count()))
                .ForMember(tsVM=>tsVM.SeasonCount, opt=>opt.MapFrom(ts=>ts.Seasons.Count()));
        }
    }
}
