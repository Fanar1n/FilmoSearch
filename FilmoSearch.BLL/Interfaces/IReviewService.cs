using FilmoSearch.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmoSearch.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllAsync(CancellationToken token);
        Task<Review> GetByIdAsync(int id, CancellationToken token);
        Task<Review> CreateAsync(Review item, CancellationToken token);
        Task<Review> UpdateAsync(Review item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
