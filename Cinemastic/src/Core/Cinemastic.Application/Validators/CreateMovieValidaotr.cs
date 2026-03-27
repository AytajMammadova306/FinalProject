using Cinemastic.Application.ViewModel.Movie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Validators
{
    public class CreateMovieValidaotr:AbstractValidator<CreateMovieVM>
    {
        public CreateMovieValidaotr()
        {
            {
                RuleFor(x => x.Name)
                    .NotEmpty();
                RuleFor(x => x.TrailerUrl)
                    .NotEmpty()
                    .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute));//linki yoxluyur

                RuleFor(x => x.ImageFile)
                    .NotNull()
                    .WithMessage("Image must be uploaded.");
                RuleFor(x => x.CoverFile)
                    .NotNull()
                    .WithMessage("Cover image must be uploaded.");
                RuleFor(x => x.AgeRating)
                    .NotNull()
                    .WithMessage("Age rating must be selected.");
                RuleFor(x => x.ReleaseDate)
                    .NotNull();
                RuleFor(x => x.DurationMinutes)
                    .NotNull()
                    .GreaterThan(0);
                RuleFor(x => x.Description)
                    .NotEmpty();
                RuleFor(x => x.VideoFile)
                    .Must(f => f == null || f.Length > 0)
                    .WithMessage("Video file cannot be empty.");
            }
        }
    }
}
