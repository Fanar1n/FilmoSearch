using FilmoSearch.BLL.Models;

namespace FilmoSearch.API.Test.Models
{
    public class ValidReview
    {
        public static Review Review = new()
        {
            Id = 1,
            Title = "Hilarious",
            Description = "Good film with wonderful actors",
            Stars = 5,
            FilmId = 1
        };

        public static IEnumerable<Review> ListReview = new List<Review>()
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
    }
}
