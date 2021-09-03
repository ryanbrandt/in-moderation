using InModeration.Backend.API.Data;
using InModeration.Backend.API.Data.Repositories;
using InModeration.Backend.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public class SiteRuleService : ISiteRuleService
    {
        private readonly ISiteRuleRepository _siteRuleRepository;

        private readonly IUnitOfWork _work;

        public SiteRuleService(ISiteRuleRepository siteRuleRepository, IUnitOfWork work)
        {
            _siteRuleRepository = siteRuleRepository;
            _work = work;
        }

        public async Task CreateSiteRuleAsync(SiteRule rule)
        {
            await _siteRuleRepository.CreateAsync(rule);
            await _work.CompleteAsync();
        }

        public async Task DeleteSiteRuleAsync(SiteRule rule)
        {
            await _siteRuleRepository.DeleteAsync(rule);
            await _work.CompleteAsync();
        }

        public async Task<SiteRule> FindSiteRuleAsync(int userId, int siteId)
        {
            var rule = await _siteRuleRepository.FindAsync(userId, siteId);

            return rule;
        }

        public async Task<IEnumerable<SiteRule>> ListSiteRulesAsync(int userId, int? siteId, bool includeSite = false)
        {
            var rules = await _siteRuleRepository.ListAsync(userId, siteId, includeSite);

            return rules;
        }

        public async Task UpdateSiteRuleAsync(SiteRule rule, SiteRule updatedRule)
        {
            await _siteRuleRepository.UpdateAsync(rule, updatedRule);
            await _work.CompleteAsync();
        }
    }
}
