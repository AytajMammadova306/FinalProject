using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Account
{
    public class LogInVM
    {
        public string UserNameOrEmail {  get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistance {  get; set; }
    }
}
