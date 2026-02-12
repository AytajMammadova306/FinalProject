using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.MVC.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Home
{
    public class HomePageVM
    {
        public ICollection<GetMovieItemVM> LatestMovieItemVMs { get; set; }
        public ICollection<GetMovieItemVM> CommingMovieItemVMs { get; set; }
        public ICollection<GetTvShowItemVM> RecommendedTVShowItemVM { get; set; }
    }
}
