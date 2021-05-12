using AutoMapper;
using InModeration.Backend.API.Constants;
using InModeration.Backend.API.Errors;
using InModeration.Backend.API.Models;
using InModeration.Backend.API.Models.Extensions;
using InModeration.Backend.API.Resources;
using InModeration.Backend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
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

        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException(HttpStatusCode.BadRequest, ModelState.GetErrors());
            }

            var user = _mapper.Map<SaveUserResource, User>(resource);
            await _userService.CreateUserAsync(user);

            return Created("", user);
        }
    }
}
