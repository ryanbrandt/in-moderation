namespace InModeration.Backend.API.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _db;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
