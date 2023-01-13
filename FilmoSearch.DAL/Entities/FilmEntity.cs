using System.Collections.Generic;

namespace FilmoSearch.DAL.Entities
{
    public class FilmEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ActorEntityFilmEntity> ActorFilms { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
