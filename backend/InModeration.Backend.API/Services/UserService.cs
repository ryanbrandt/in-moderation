using InModeration.Backend.API.Data;
using InModeration.Backend.API.Data.Repositories;
using InModeration.Backend.API.Models;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _work;

        public UserService(IUserRepository userRepository, IUnitOfWork work)
        {
            _userRepository = userRepository;
            _work = work;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateAsync(user);
            await _work.CompleteAsync();
        }
    }
}
