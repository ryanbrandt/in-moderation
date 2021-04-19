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
    [Route("v{version:apiVersion}/user")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _db
                .Users
                .Add(user);

            _db.SaveChanges();

            return Created("", new { user.Id });
        }

    }
}
