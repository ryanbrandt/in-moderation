using InModeration.Backend.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public interface ISiteRuleService
    {
        Task<SiteRule> FindSiteRuleAsync(int userId, int siteId);

        Task CreateSiteRuleAsync(SiteRule rule);

        Task<IEnumerable<SiteRule>> ListSiteRulesAsync(int userId, int? siteId, bool includeSite = false);

        Task UpdateSiteRuleAsync(SiteRule rule, SiteRule updatedRule);

        Task DeleteSiteRuleAsync(SiteRule rule);
    }
}
