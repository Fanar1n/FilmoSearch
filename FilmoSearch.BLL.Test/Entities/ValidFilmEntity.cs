using FilmoSearch.DAL.Entities;

namespace FilmoSearch.BLL.Test.Entities
{
    public class ValidFilmEntity
    {
        public static FilmEntity FilmEntity = new()
        {
            Id = 1,
            Title = "Dirty Jerry",
        };

        public static IEnumerable<FilmEntity> ListFilmEntity = new List<FilmEntity>()
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
