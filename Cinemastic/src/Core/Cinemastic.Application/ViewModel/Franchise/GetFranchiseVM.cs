using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Franchise
{
    public class GetFranchiseVM
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int ContentCount { get; set; } = 0;
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string CoverUrl { get; set; }
        public string Description { get; set; }
    }
}
