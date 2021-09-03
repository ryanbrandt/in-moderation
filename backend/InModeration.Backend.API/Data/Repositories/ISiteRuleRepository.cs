using InModeration.Backend.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Data.Repositories
{
    public interface ISiteRuleRepository
    {
        Task<SiteRule> FindAsync(int userId, int siteId);

        Task CreateAsync(SiteRule rule);

        Task<IEnumerable<SiteRule>> ListAsync(int userId, int? siteId, bool includeSite = false);

        Task UpdateAsync(SiteRule rule, SiteRule updatedRule);

        Task DeleteAsync(SiteRule rule);
    }
}
