using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

using InModeration.Backend.API.Models;

namespace InModeration.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteRuleController : ControllerBase
    {
        private readonly ILogger<SiteRuleController> _logger;

        public SiteRuleController(ILogger<SiteRuleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SiteRule> Get()
        {
            var dummy = new List<SiteRule>();
            
            return dummy;
        }
    }
}
