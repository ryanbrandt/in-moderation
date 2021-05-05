using InModeration.Backend.API.Models;
using System.Threading.Tasks;

namespace InModeration.Backend.API.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        { }

        public async Task CreateAsync(User user)
        {
            await _db
                .Users
                .AddAsync(user);

            await _db.SaveChangesAsync();
        }
    }
}
