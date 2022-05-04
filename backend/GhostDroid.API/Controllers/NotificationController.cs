using GhostDroid.Application.Commands.Notification;
using Microsoft.AspNetCore.Mvc;

namespace GhostDroid.API.Controllers
{
    public class NotificationController : BaseController
    {
        public NotificationController(IMediator meditor) : base(meditor)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateNotificationCommand command)
        {
            await _meditor.Send(command);
            return Ok();
        }
    }
}
