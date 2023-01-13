using FilmoSearch.DAL.EF;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;

namespace FilmoSearch.DAL.Repository
{
    public class FilmRepository : GenericRepository<FilmEntity>, IFilmRepository
    {
        public FilmRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}
