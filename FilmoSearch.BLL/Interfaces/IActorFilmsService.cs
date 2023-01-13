using FilmoSearch.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmoSearch.BLL.Interfaces
{
    public interface IActorFilmsService
    {
        Task<IEnumerable<ActorFilms>> GetAllAsync(CancellationToken token);
        Task<ActorFilms> GetByIdAsync(int id, CancellationToken token);
        Task<ActorFilms> CreateAsync(ActorFilms item, CancellationToken token);
        Task<ActorFilms> UpdateAsync(ActorFilms item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
