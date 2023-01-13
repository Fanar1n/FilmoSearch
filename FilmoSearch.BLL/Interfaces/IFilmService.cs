using FilmoSearch.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmoSearch.BLL.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAllAsync(CancellationToken token);
        Task<Film> GetByIdAsync(int id, CancellationToken token);
        Task<Film> CreateAsync(Film item, CancellationToken token);
        Task<Film> UpdateAsync(Film item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
