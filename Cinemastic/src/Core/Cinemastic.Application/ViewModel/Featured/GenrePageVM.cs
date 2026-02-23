using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Featured
{
    public class GenrePageVM
    {
        public ICollection<GenreCardVM> MovieGenres { get; set; }
        public ICollection<GenreCardVM> TvShowGenres { get; set; }

    }
}
