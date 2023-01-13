using FilmoSearch.DAL.EF;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;

namespace FilmoSearch.DAL.Repository
{
    public class ReviewRepository : GenericRepository<ReviewEntity>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}
