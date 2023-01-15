using FilmoSearch.BLL.Models;

namespace FilmoSearch.BLL.Test.Models
{
    public class ValidActor
    {
        public static Actor Actor = new()
        {
            Id = 1,
            FirstName = "Vlad",
            LastName = "Zagorsky",
        };

        public static IEnumerable<Actor> ListActor = new List<Actor>()
        {
            new()
            {
                Id = 1,
                FirstName = "Vlad",
                LastName = "Zagorsky",
            },
            new()
            {
                Id = 2,
                FirstName = "Robert",
                LastName = "Paulson"
            }
        };
    }
}
