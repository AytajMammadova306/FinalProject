using Cinemastic.Application.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Home
{
    public class AllMoviesVM
    {
        public ICollection<GetMovieItemVM> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Take { get; set; }
    }
}
