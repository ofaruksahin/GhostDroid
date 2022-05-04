using AutoMapper;
using GhostDroid.Domain.Services.Interfaces;

namespace GhostDroid.Application.Commands.Notification
{
    public abstract class BaseNotificationCommandHandler : BaseCommandHandler
    {
        protected readonly INotificationService _notificationService;

        protected BaseNotificationCommandHandler(
            IMapper mapper,
            INotificationService notificationService) : base(mapper)
        {
            _notificationService = notificationService;
        }
    }
}
