using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Slide
{
    public class GetSlideVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContentId { get; set; }
        public int? SeasonOrDuration { get; set; }
        public string AgeRating { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public ICollection<string> Genres { get; set; }
        public ICollection<string> Tags {  get; set; }
        public ICollection<string> Starrings { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool IsMovie { get; set; }
    }
}
