using FilmoSearch.DAL.Entities;
using System.Collections.Generic;

namespace FilmoSearch.BLL.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
