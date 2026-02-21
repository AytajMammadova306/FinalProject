using AutoMapper;
using Cinemastic.Application.ViewModel.Episode;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.MappingProfiles
{
    internal class EpisodeProfile:Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, GetEpisodeItemVM>();
        }
    }
}
