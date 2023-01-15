using FilmoSearch.API.ViewModels.Review;

namespace FilmoSearch.API.Test.ViewModels
{
    public class ValidReviewViewModel
    {
        public static ReviewViewModel ReviewViewModel = new()
        {
            Id = 1,
            Title = "Hilarious",
            Description = "Good film with wonderful actors",
            Stars = 5,
            FilmId = 1
        };

        public static IEnumerable<ReviewViewModel> ListReviewViewModel = new List<ReviewViewModel>()
        {
            new()
            {
                Id = 1,
                Title = "Hilarious",
                Description = "Good film with wonderful actors",
                Stars = 5,
                FilmId = 1
            },
            new()
            {
                Id = 2,
                Title = "Harsh",
                Description = "Film where u can see a lot of blood and filthy scenes",
                Stars = 3,
                FilmId = 1
            }
        };

        public static ShortReviewViewModel ShortReviewViewModel = new()
        {
            Title = "Hilarious",
            Description = "Good film with wonderful actors",
            Stars = 5,
            FilmId = 1
        };
    }
}
