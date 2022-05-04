using GhostDroid.Domain.Models;

namespace GhostDroid.Domain.Services.Interfaces
{
    public interface INotificationService
    {
        Task Insert(Notification model);
    }
}
