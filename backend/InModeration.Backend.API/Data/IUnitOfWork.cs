using System.Threading.Tasks;

namespace InModeration.Backend.API.Data
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
