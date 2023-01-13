using FilmoSearch.API.ViewModels.ActorFilms;
using FluentValidation;
using System.Data;

namespace FilmoSearch.API.Validator
{
    public class ActorFilmValidator : AbstractValidator<ShortActorFilmsViewModel>
    {
        public ActorFilmValidator()
        {
            RuleFor(x => x.ActorId).NotNull();
            RuleFor(x => x.FilmId).NotNull();
        }
    }
}
