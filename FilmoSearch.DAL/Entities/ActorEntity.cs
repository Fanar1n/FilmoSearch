using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Collections.Generic;

namespace FilmoSearch.DAL.Entities
{
    public class ActorEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ActorEntityFilmEntity> ActorFilms { get; set; }
    }
}
