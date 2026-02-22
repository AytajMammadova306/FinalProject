using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Account
{
    public class RegisterVM
    {
        [MinLength(4)]
        public string UserName { get; set; }
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(25)]
        public string Surname { get; set; }
        [MaxLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
