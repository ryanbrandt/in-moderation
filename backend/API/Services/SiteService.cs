using InModeration.Backend.API.Data.Repositories;
using InModeration.Backend.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public async Task<Site> FindSiteAsync(int id)
        {
            var site = await _siteRepository.FindAsync(id);

            return site;
        }

        public async Task CreateSiteAsync(Site site)
        {
            await _siteRepository.CreateAsync(site);
        }

        public async Task<IEnumerable<Site>> ListSitesAsync(int? id, string? domain)
        {
            var sites = await _siteRepository.ListAsync(id, domain);

            return sites;
        }
    }
}
