using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Enums
{
    public enum TvShowAgeRating
    {
        [Display(Name = "TV-Y")]
        TVY,
        [Display(Name = "TV-Y7")]
        TVY7,
        [Display(Name = "TV-Y7-FV")]
        TVY7_FV,
        [Display(Name = "TV-G")]
        TVG,
        [Display(Name = "TV-PG")]
        TVPG,
        [Display(Name = "TV-14")]
        TV14,
        [Display(Name = "TV-MA")]
        TVMA
    }
}
