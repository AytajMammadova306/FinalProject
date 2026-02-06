using AutoMapper;
using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Domain.Entities;
using Cinemastic.MVC.ViewModel.Movie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class ContentService:IContentService
    {
        private readonly IContentRepository _repository;
        private readonly IMapper _mapper;

        public ContentService(
            IContentRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper=mapper;
        }
        
        public async Task<ICollection<GetContentItemVM>> GetAllAsync()
        {
            IReadOnlyList<Content> contents = await _repository.GetAll(
                includes: "ContentGenres.Genre")
                .ToListAsync();
            ICollection<GetContentItemVM> contentVms = _mapper.Map<ICollection<GetContentItemVM>>(contents);
            return contentVms;
        }
    }
}
