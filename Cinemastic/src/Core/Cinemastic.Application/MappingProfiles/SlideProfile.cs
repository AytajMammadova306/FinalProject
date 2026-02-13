using AutoMapper;
using Cinemastic.Application.ViewModel.Slide;
using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class SlideProfile:Profile
    {
        public SlideProfile()
        {
            CreateMap<Slide, GetSlideVM>()

                .ForMember(sVM => sVM.Name,
                opt => opt.MapFrom(s =>
                s.Movie != null
                ? s.Movie.Name
                : s.TvShow.Name))

                .ForMember(sVM => sVM.Description,
                opt => opt.MapFrom(s =>
                s.Movie != null
                ? s.Movie.Description
                : s.TvShow.Description))

                .ForMember(sVM => sVM.ContentId,
                opt => opt.MapFrom(s => s.MovieId ?? s.TvShowId ?? 0))

                .ForMember(dest => dest.SeasonOrDuration,
                opt => opt.MapFrom(src =>
                src.Movie != null
                ? src.Movie.DurationMinutes ?? 0
                : src.TvShow.EpisodeCount))

                .ForMember(dest => dest.AgeRating,
                opt => opt.MapFrom(src =>
                src.Movie != null
                ? src.Movie.AgeRating.ToString()
                : src.TvShow.AgeRating.ToString()))

                .ForMember(sVM => sVM.Genres,
                opt => opt.MapFrom(s =>
                s.Movie != null
                ? s.Movie.MovieGenres
                    .Select(mg => mg.Genre.Name)
                : s.TvShow.TvShowGenres
                    .Select(tg => tg.Genre.Name)))

                .ForMember(sVM => sVM.Tags,
                opt => opt.MapFrom(s =>
                s.Movie != null
                ? s.Movie.MovieTags
                    .Select(mt => mt.Tag.Name)
                : s.TvShow.TvShowTags
                    .Select(tt => tt.Tag.Name)))

                 .ForMember(sVM => sVM.ReleaseDate,
                 opt => opt.MapFrom(s =>
                 s.Movie != null
                 ? s.Movie.ReleaseDate
                 : s.TvShow.ReleaseDate))

                 .ForMember(sVM=>sVM.IsMovie,
                 opt=>opt.MapFrom(s=>s.Movie !=null))

                .ForMember(sVM => sVM.Starrings,
                opt => opt.MapFrom(s =>
                s.Movie != null
                ? s.Movie.MovieCasts
                    .Where(mc => mc.Role == RoleType.Lead)
                    .Select(mc => mc.Actor.Name + " " + mc.Actor.Surname)
                : s.TvShow.TvShowCasts
                    .Where(tc => tc.Role == RoleType.Lead)
                    .Select(tc => tc.Actor.Name + " " + tc.Actor.Surname)))

            ;
        }
    }
}
