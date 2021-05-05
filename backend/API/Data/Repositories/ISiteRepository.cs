using InModeration.Backend.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Data.Repositories
{
    public interface ISiteRepository
    {
        Task<Site> FindAsync(int id);

        Task CreateAsync(Site site);

        Task<IEnumerable<Site>> ListAsync(int? id, string? domain);
    }
}
