using Cinemastic.MVC.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Home
{
    public class PreviewPageVM
    {
        public ICollection<GetMovieItemVM> LatestMovies {  get; set; }
        public Dictionary<string, string> Settings { get; set; }
        

    }
}
