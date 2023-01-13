using FilmoSearch.DAL.EF;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;

namespace FilmoSearch.DAL.Repository
{
    public class ActorRepository : GenericRepository<ActorEntity>, IActorRepository
    {
        public ActorRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}
