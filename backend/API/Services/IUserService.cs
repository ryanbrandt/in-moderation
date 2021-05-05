using InModeration.Backend.API.Models;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
    }
}
