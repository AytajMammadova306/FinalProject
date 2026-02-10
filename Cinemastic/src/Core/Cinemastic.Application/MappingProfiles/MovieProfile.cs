using AutoMapper;
using Cinemastic.Domain.Entities;
using Cinemastic.MVC.ViewModel.Movie;
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
                .ForMember(cVM => cVM.Genres, opt => opt.MapFrom(c =>
                    c.MovieGenres
                    .Select(cg => cg.Genre.Name)
                    .Take(2)
                    .ToList()))
                .ForMember(cVM=>cVM.GenresCount,opt=>opt.MapFrom(c=>c.MovieGenres.Count()));

        }
    }
}
