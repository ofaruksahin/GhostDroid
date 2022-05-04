using GhostDroid.Domain.Models;
using GhostDroid.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GhostDroid.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseModel
    {
        protected readonly GhostDroidDbContext _dbContext;
        protected DbSet<T> _dbSet;

        protected GenericRepository(GhostDroidDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<int> Insert(T model)
        {
            var entity = await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
            return entity.Entity.Id;
        }
    }
}
