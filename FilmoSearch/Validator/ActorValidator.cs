using FilmoSearch.API.ViewModels.Actor;
using FluentValidation;

namespace FilmoSearch.API.Validator
{
    public class ActorValidator : AbstractValidator<ShortActorViewModel>
    {
        public ActorValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 50).NotNull();
            RuleFor(x => x.LastName).Length(2, 50).NotNull();
        }
    }
}
