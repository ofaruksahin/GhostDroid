using GhostDroid.Domain.Models;
using GhostDroid.Domain.Repositories;

namespace GhostDroid.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(GhostDroidDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
