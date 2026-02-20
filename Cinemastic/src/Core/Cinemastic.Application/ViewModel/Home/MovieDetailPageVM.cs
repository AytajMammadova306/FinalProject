using Cinemastic.Application.ViewModel.Actor;
using Cinemastic.Application.ViewModel.Crew;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.MVC.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Home
{
    public class MovieDetailPageVM
    {
        public GetMovieVM MovieVM { get; set; }
        public ICollection<GetActorVM> Starring {  get; set; }
        public ICollection<GetCrewVM> Crews {  get; set; }
        public ICollection<GetMovieItemVM> ComingMovieItemVMs { get; set; }
    }
}
