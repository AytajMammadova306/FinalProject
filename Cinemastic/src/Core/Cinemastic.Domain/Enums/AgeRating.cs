using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Enums
{
    public enum AgeRating
    {
        [Display(Name = "G")]
        G,
        [Display(Name = "PG")]
        PG,
        [Display(Name = "PG-13")]
        PG13,
        [Display(Name = "R")]
        R,
        [Display(Name = "NC-17")]
        NC17
    }
}
