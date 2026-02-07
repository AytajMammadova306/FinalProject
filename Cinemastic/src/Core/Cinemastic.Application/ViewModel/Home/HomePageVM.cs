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
        public ICollection<GetContentItemVM> LatestContentItemVMs { get; set; }
        public ICollection<GetContentItemVM> CommingContentItemVMs { get; set; }
    }
}
