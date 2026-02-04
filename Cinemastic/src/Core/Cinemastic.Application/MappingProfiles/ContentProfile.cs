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
    internal class ContentProfile:Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, GetContentVM>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src =>
                    src.ContentGenres
                    .Select(cg => cg.Genre)
                    .OrderByDescending(g => g.ContentGenres.Count)
                    .FirstOrDefault()
                    .Name
    ));

        }
    }
}
