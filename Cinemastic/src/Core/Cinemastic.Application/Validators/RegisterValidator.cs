using Cinemastic.Application.ViewModel.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Validators
{
    public class RegisterValidator:AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName)
            .MinimumLength(4);

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .MaximumLength(25);

            RuleFor(x => x.Surname)
                .MinimumLength(3)
                .MaximumLength(25);

            RuleFor(x => x.Email)
                .MaximumLength(128)
                .EmailAddress();
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Passwords must match");
            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
