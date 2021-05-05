using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.ONE)]
    [Route("v{version:apiVersion}/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _userService.CreateUserAsync(user);

            return Created("", user);
        }
    }
}
