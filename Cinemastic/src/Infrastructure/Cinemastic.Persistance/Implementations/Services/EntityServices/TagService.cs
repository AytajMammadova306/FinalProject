using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Featured;
using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class TagService:ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(
            ITagRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<TagCardVM>> GetMovieTagCardVMs()
        {
            IReadOnlyList<Tag> tags= await _repository.GetAll(func:t=>t.MovieTags.Count()>0).ToListAsync();
            return _mapper.Map<ICollection<TagCardVM>>(tags);
        }
        public async Task<ICollection<TagCardVM>> GetTvShowTagCardVMs()
        {
            IReadOnlyList<Tag> tags = await _repository.GetAll(func: t => t.TvShowTags.Count() > 0).ToListAsync();
            return _mapper.Map<ICollection<TagCardVM>>(tags);
        }
        public async Task<ICollection<Tag>> GetAllTagsAsync()
        {
            ICollection<Tag> tags = await _repository.GetAll().ToListAsync();
            return tags;
        }
    }
}
