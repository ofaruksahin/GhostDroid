using GhostDroid.Domain.Models;
using GhostDroid.Domain.Repositories;
using GhostDroid.Domain.Services.Interfaces;

namespace GhostDroid.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository
                ?? throw new ArgumentNullException(nameof(notificationRepository));
        }

        public async Task Insert(Notification model)
        {
          await _notificationRepository.Insert(model);
        }
    }
}
