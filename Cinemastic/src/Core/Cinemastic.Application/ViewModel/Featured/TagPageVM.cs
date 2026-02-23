using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Featured
{
    public class TagPageVM
    {
        public ICollection<TagCardVM> MovieTags { get; set; }
        public ICollection<TagCardVM> TvShowTags { get; set; }
    }
}
