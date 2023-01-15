using FilmoSearch.BLL.Models;

namespace FilmoSearch.API.Test.Models
{
    public class ValidFilm
    {
        public static Film Film = new()
        {
            Id = 1,
            Title = "Dirty Jerry",
        };

        public static IEnumerable<Film> ListFilm = new List<Film>()
        { new ()
        {
            Id = 1,
            Title= "Dirty Jerry",
        },
        new()
        {
            Id = 2,
            Title = "Big daddy boy"
        }
        };
    }
}
