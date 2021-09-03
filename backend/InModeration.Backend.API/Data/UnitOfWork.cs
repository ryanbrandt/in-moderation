using System.Threading.Tasks;

namespace InModeration.Backend.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
