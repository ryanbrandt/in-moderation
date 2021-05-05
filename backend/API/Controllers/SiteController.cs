using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.ONE)]
    [Route("v{version:apiVersion}/site")]
    public class SiteController : Controller
    {
        private readonly ISiteService _siteService;

        private readonly ILogger<SiteController> _logger;

        public SiteController(ILogger<SiteController> logger, ISiteService siteService)
        {
            _logger = logger;
            _siteService = siteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Site site)
        {
            await _siteService.CreateSiteAsync(site);

            return CreatedAtAction("Get", new { site.Id }, site);
        }

        [HttpGet]
        public async Task<IEnumerable<Site>> Get([FromQuery] int? id, [FromQuery] string? domain)
        {
            var sites = await _siteService.ListSitesAsync(id, domain);

            return sites;
        }

    }
}
