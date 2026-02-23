using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.Application.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemastic.Application.ViewModel.Franchise;

namespace Cinemastic.Application.ViewModel.Home
{
    public class FranchiseDetailPageVM
    {
        public GetFranchiseVM FranchiseVM {  get; set; }
        public ICollection<GetMovieItemVM> Movies { get; set; }
        public ICollection<GetTvShowItemVM> TvShows { get; set; }
    }
}
