using FilmoSearch.API.ViewModels.Review;
using FluentValidation;

namespace FilmoSearch.API.Validator
{
    public class ReviewValidator : AbstractValidator<ShortReviewViewModel>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Title).Length(2, 50).NotNull();
            RuleFor(x => x.Description).Length(2, 150).NotNull();
            RuleFor(x => x.Stars).InclusiveBetween(1, 5).WithMessage("the stars must be greater than one and less than five").NotNull();
            RuleFor(x => x.FilmId).NotNull();
        }
    }
}
