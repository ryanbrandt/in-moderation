using InModeration.Backend.API.Data.Extensions;
using InModeration.Backend.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Data.Repositories
{
    public class SiteRuleRepository : BaseRepository, ISiteRuleRepository
    {
        public SiteRuleRepository(ApplicationDbContext db) : base(db)
        { }

        public async Task<SiteRule> FindAsync(int userId, int siteId)
        {
            var rule = await _db
                          .SiteRules
                          .SingleOrDefaultAsync(siteRule => siteRule.UserId == userId && siteRule.UserId == siteId);

            return rule;
        }

        public async Task CreateAsync(SiteRule rule)
        {
            await _db
                .SiteRules
                .AddAsync(rule);
        }

        public async Task<IEnumerable<SiteRule>> ListAsync(int userId, int? siteId, bool includeSite = false)
        {
            var rules = await _db
                          .SiteRules
                          .Where(siteRule => siteRule.UserId == userId)
                          .WhereIf((siteId != null), siteRule => siteRule.SiteId == siteId)
                          .IncludeIf((includeSite), "Site")
                          .ToListAsync();

            return rules;
        }

        public async Task UpdateAsync(SiteRule rule, SiteRule updatedRule)
        {
            _db
                .Entry(updatedRule)
                .CurrentValues
                .SetValues(updatedRule);
        }

        public async Task DeleteAsync(SiteRule rule)
        {
            _db
                .SiteRules
                .Remove(rule);
        }
    }
}
