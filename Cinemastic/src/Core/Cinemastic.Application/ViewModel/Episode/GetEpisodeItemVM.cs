using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Episode
{
    public class GetEpisodeItemVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public int EpisodNumber { get; set; }
        public long SeasonId { get; set; }
    }
}
