using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using InModeration.Backend.API.Data;
using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Models;

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

            return Created("", new { site.Id });
        }
        
    }
}
