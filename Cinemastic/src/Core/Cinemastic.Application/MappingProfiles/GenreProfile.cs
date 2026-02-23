using AutoMapper;
using Cinemastic.Application.ViewModel.Featured;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class GenreProfile:Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreCardVM>()
                .ForMember(dest => dest.GenreId,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
