using FilmoSearch.API.ViewModels.Film;
using FluentValidation;

namespace FilmoSearch.API.Validator
{
    public class FilmValidator : AbstractValidator<ShortFilmViewModel>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Title).Length(2, 50).NotNull();
        }
    }
}
