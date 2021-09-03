using InModeration.Backend.API.Data.Extensions;
using InModeration.Backend.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Data.Repositories
{
    public class SiteRepository : BaseRepository, ISiteRepository
    {
        public SiteRepository(ApplicationDbContext db) : base(db)
        { }

        public async Task<Site> FindAsync(int id)
        {
            var site = await _db.Sites.SingleOrDefaultAsync(site => site.Id == id);

            return site;
        }

        public async Task CreateAsync(Site site)
        {
            await _db
                 .Sites
                 .AddAsync(site);
        }

        public async Task<IEnumerable<Site>> ListAsync(int? id, string? domain)
        {
            var sites = await _db
                            .Sites
                            .WhereIf((id != null), site => site.Id == id)
                            .WhereIf((domain != null), site => site.Domain.Contains(domain))
                            .ToListAsync();

            return sites;
        }
    }
}
