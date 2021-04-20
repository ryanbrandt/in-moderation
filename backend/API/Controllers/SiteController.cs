using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using InModeration.Backend.API.Data;
using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Data.Extensions;

namespace InModeration.Backend.API.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.ONE)]
    [Route("v{version:apiVersion}/site")]
    public class SiteController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private readonly ILogger<SiteController> _logger;

        public SiteController(ILogger<SiteController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Site site)
        {
            _db
                .Sites
                .Add(site);

            _db.SaveChanges();

            return CreatedAtAction("Get", new { site.Id }, site);
        }

        [HttpGet]
        public IEnumerable<Site> Get([FromQuery] int? id, [FromQuery] string? domain)
        {
            var sites = _db
                            .Sites
                            .WhereIf((id != null), site => site.Id == id)
                            .WhereIf((domain != null), site => site.Domain.Contains(domain));

            return sites;
        }
        
    }
}
