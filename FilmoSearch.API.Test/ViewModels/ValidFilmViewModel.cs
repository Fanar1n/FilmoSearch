using FilmoSearch.API.ViewModels.Film;

namespace FilmoSearch.API.Test.ViewModels
{
    public class ValidFilmViewModel
    {
        public static FilmViewModel FilmViewModel = new()
        {
            Id = 1,
            Title = "Dirty Jerry",
        };

        public static IEnumerable<FilmViewModel> ListFilmViewModel = new List<FilmViewModel>()
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

        public static ShortFilmViewModel ShortFilmViewModel = new()
        {
            Title = "Dirty Jerry",
        };
    }
}
