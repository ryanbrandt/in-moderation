using InModeration.Backend.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public interface ISiteService
    {
        Task<Site> FindSiteAsync(int id);

        Task CreateSiteAsync(Site site);

        Task<IEnumerable<Site>> ListSitesAsync(int? id, string? domain);
    }
}
