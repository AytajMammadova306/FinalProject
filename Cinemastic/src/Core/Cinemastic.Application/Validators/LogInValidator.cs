using Cinemastic.Application.ViewModel.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Validators
{
    public class LogInValidator:AbstractValidator<LogInVM>
    {
        public LogInValidator()
        {
            RuleFor(u => u.UserNameOrEmail)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(256)
                .Matches(@"^[A-Za-z0-9-.@+]*$");
            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
