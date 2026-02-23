using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Movie
{
    public class GetMovieAdminPageVM
    {
        public ICollection<GetMovieAdminVM> Movies { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Take { get; set; }
    }
}
