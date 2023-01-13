using FilmoSearch.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmoSearch.BLL.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllAsync(CancellationToken token);
        Task<Actor> GetByIdAsync(int id, CancellationToken token);
        Task<Actor> CreateAsync(Actor item, CancellationToken token);
        Task<Actor> UpdateAsync(Actor item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
