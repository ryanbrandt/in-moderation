using InModeration.Backend.API.Data.Repositories;
using InModeration.Backend.API.Models;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }
    }
}
