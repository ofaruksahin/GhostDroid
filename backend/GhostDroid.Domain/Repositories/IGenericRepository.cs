using GhostDroid.Domain.Models;

namespace GhostDroid.Domain.Repositories
{
    public interface IGenericRepository<T>
        where T : BaseModel
    {
        Task<int> Insert(T model);
    }
}
