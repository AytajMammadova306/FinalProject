using AutoMapper;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Domain.Entities;
using Cinemastic.Application.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, GetMovieItemVM>()
                .ForMember(mVM => mVM.Genres, opt => opt.MapFrom(m =>
                    m.MovieGenres
                    .Select(mg => mg.Genre.Name)
                    .Take(2)
                    .ToList()))
                .ForMember(mVM=>mVM.GenresCount,opt=>opt.MapFrom(m=>m.MovieGenres.Count()));


            CreateMap<Movie, GetMovieVM>()
                .ForMember(mVM => mVM.AgeRating, opt => opt.MapFrom(m => 
                    m.AgeRating.ToString().Replace("_", "-")))

                .ForMember(mVM => mVM.FranchiseName,
                    opt => opt.MapFrom(m => m.Franchise != null
                    ? m.Franchise.Name
                    : null))

                .ForMember(mVM => mVM.Genres,
                    opt => opt.MapFrom(m => m.MovieGenres
                    .Select(mg => mg.Genre.Name)))

                .ForMember(mVM => mVM.Tags,
                    opt => opt.MapFrom(m => m.MovieTags
                    .Select(mt => mt.Tag.Name)))

                .ForMember(mVM => mVM.Casts,
                    opt => opt.MapFrom(m => m.MovieCasts
                    .Select(mc => mc.Actor.Name + " " + mc.Actor.Surname)))

                .ForMember(mVM => mVM.Crews,
                    opt => opt.MapFrom(m => m.MovieCrews
                    .Select(mc => mc.Crew.Name+ " "+ mc.Crew.Surname)));

			CreateMap<Movie, GetMovieAdminVM>()
	            .ForMember(dest => dest.Id,
		            opt => opt.MapFrom(src => src.Id))
	            .ForMember(dest => dest.Date,
		            opt => opt.MapFrom(src => src.ReleaseDate ?? DateTime.MinValue));

		}
    }
}
