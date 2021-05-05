using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.ONE)]
    [Route("v{version:apiVersion}/rule")]
    public class SiteRuleController : ControllerBase
    {
        private const string SINGLE_RESOURCE_PATH = "user/{userId}/site/{siteId}";

        private readonly ISiteRuleService _siteRuleService;

        private readonly ISiteService _siteService;

        private readonly ILogger<SiteRuleController> _logger;

        public SiteRuleController(ILogger<SiteRuleController> logger, ISiteRuleService siteRuleService, ISiteService siteService)
        {
            _logger = logger;
            _siteRuleService = siteRuleService;
            _siteService = siteService;
        }

        private async Task<SiteRule> GetRuleOrThrow(int userId, int siteId)
        {
            var rule = await _siteRuleService.FindSiteRuleAsync(userId, siteId);

            if (rule == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Site rule does not exist");
            }

            return rule;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SiteRule rule)
        {
            await _siteRuleService.CreateSiteRuleAsync(rule);

            var associatedSite = await _siteService.FindSiteAsync(rule.SiteId);
            rule.Site = associatedSite;

            return CreatedAtAction("Get", new { rule.UserId, rule.SiteId }, new SiteRulePayload(rule));
        }

        [HttpGet("user/{userId}")]
        public async Task<IEnumerable<SiteRulePayload>> Get(int userId, [FromQuery] int? siteId)
        {
            var rules = await _siteRuleService.ListSiteRulesAsync(userId, siteId, true);
            var rulesPayload = rules.Select(rule => new SiteRulePayload(rule));

            return rulesPayload;
        }

        [HttpPut(SINGLE_RESOURCE_PATH)]
        public async Task<IActionResult> Put(int userId, int siteId, [FromBody] SiteRule updatedRule)
        {
            var rule = await GetRuleOrThrow(userId, siteId);

            await _siteRuleService.UpdateSiteRuleAsync(rule, updatedRule);

            return NoContent();
        }

        [HttpDelete(SINGLE_RESOURCE_PATH)]
        public async Task<IActionResult> Delete(int userId, int siteId)
        {
            var rule = await GetRuleOrThrow(userId, siteId);

            await _siteRuleService.DeleteSiteRuleAsync(rule);

            return NoContent();
        }
    }
}
