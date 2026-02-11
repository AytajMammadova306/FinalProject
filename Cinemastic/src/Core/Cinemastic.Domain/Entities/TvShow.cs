using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class TvShow:BaseNameableEntity
    {
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public int EpisodeCount { get; set; }
        public int? FranchiseId {  get; set; }
        public Franchise? Franchise { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Season> Seasons { get; set; }


    }
}
