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

            CreateMap<TvShow, GetTvShowVM>()
            .ForMember(dest => dest.AgeRating,
                opt => opt.MapFrom(src => src.AgeRating.ToString().Replace("_", "-")))

            .ForMember(dest => dest.FranchiseName,
                opt => opt.MapFrom(src => src.Franchise.Name))

            .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.TvShowGenres
                .Select(g => g.Genre.Name)))

            .ForMember(dest => dest.Tags,
                opt => opt.MapFrom(src => src.TvShowTags
                .Select(t => t.Tag.Name)))

            .ForMember(dest => dest.Casts,
                opt => opt.MapFrom(src => src.TvShowCasts
                .Select(c => c.Actor.Name+" "+c.Actor.Surname)))

            .ForMember(dest => dest.Crews,
                opt => opt.MapFrom(src => src.TvShowCrews
                .Select(c => c.Crew.Name+" "+c.Crew.Surname)))

            .ForMember(dest => dest.SeasonIds,
                opt => opt.MapFrom(src => src.Seasons
                .Select(s => s.Id)))

            .ForMember(dest => dest.Episodes,
                opt => opt.MapFrom(src => src.Seasons
                .SelectMany(s => s.Episodes)));
        }
    }
}
