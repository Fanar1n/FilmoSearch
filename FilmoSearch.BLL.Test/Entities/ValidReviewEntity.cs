using FilmoSearch.DAL.Entities;

namespace FilmoSearch.BLL.Test.Entities
{
    public class ValidReviewEntity
    {
        public static ReviewEntity ReviewEntity = new()
        {
            Id = 1,
            Title = "Hilarious",
            Description = "Good film with wonderful actors",
            Stars = 5,
            FilmId = 1
        };

        public static IEnumerable<ReviewEntity> ListReviewEntity = new List<ReviewEntity>()
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
