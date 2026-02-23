using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Featured
{
    public class CreateMovieVM
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string Description { get; set; }
        public AgeRating AgeRating { get; set; }
        public string TrailerUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IFormFile? CoverFile { get; set; }
        public IFormFile? VideoFile { get; set; }
        public long? FranchiseId { get; set; }
        public ICollection<long>? GenreIds { get; set; }
        public ICollection<long>? TagIds { get; set; }
        public ICollection<long>? CastIds { get; set; }
        public ICollection<long>? CrewIds { get; set; }
        public ICollection<Genre>? Genres { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<Cinemastic.Domain.Entities.Actor>? Casts { get; set; }//eyniadli folder ile qarisdirdi
        public ICollection<Cinemastic.Domain.Entities.Crew>? Crews { get; set; }
        public ICollection<Cinemastic.Domain.Entities.Franchise>? Franchises { get; set; }
    }
}
