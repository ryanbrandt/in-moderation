using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Linq;

using InModeration.Backend.API.Models;
using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Data;
using InModeration.Backend.API.Data.Extensions;

namespace InModeration.Backend.API.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.ONE)]
    [Route("v{version:apiVersion}/rule")]
    public class SiteRuleController : ControllerBase
    {
        private const string SINGLE_RESOURCE_PATH = "user/{userId}/site/{siteId}";

        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private readonly ILogger<SiteRuleController> _logger;

        public SiteRuleController(ILogger<SiteRuleController> logger)
        {
            _logger = logger;
        }

        private SiteRule RetrieveByUserAndSiteId(int? userId, int? siteId)
        {
            var rule = _db
                          .SiteRules
                          .SingleOrDefault(siteRule => siteRule.UserId == userId && siteRule.UserId == siteId);

            if (rule == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Specified site rule not found");
            }

            return rule;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SiteRule rule)
        {
            _db
                .SiteRules
                .Add(rule);

            _db.SaveChanges();

            return Created("", new { rule.UserId, rule.SiteId });
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<dynamic> Get(int userId, [FromQuery] int? siteId)
        {
            var rules = _db
                          .SiteRules
                          .Where(siteRule => siteRule.UserId == userId)
                          .WhereIf((siteId != null), siteRule => siteRule.SiteId == siteId)
                          .Include("Site")
                          .Select(
                            siteRule => new
                            {
                                siteRule.UserId,
                                siteRule.SiteId,
                                siteRule.Time,
                                siteRule.Points,
                                siteRule.Site.Domain,
                                siteRule.Created,
                                siteRule.Modified
                            }
                          );

            return rules;
        }

        [HttpPut(SINGLE_RESOURCE_PATH)]
        public IActionResult Put(int userId, int siteId, [FromBody] SiteRule updatedRule)
        {
            var rule = RetrieveByUserAndSiteId(userId, siteId);

            _db
                .Entry(rule)
                .CurrentValues
                .SetValues(updatedRule);

            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete(SINGLE_RESOURCE_PATH)]
        public IActionResult Delete(int userId, int siteId)
        {
            var rule = RetrieveByUserAndSiteId(userId, siteId);
                       
            _db
                .SiteRules
                .Remove(rule);

            _db.SaveChanges();

            return NoContent();
        }
    }
}
