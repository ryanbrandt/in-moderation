using InModeration.Backend.API.Models;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Data.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}
