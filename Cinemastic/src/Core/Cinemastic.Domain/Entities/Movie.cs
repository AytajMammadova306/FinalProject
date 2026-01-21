using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    internal class Movie:BaseNameableEntity
    {
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
