using FilmoSearch.DAL.EF;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;

namespace FilmoSearch.DAL.Repository
{
    public class ActorFilmsRepository : GenericRepository<ActorEntityFilmEntity>, IActorFilmsRepository
    {
        public ActorFilmsRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
