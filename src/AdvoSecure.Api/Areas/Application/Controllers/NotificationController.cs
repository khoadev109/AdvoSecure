using AdvoSecure.Infrastructure.Notifications;
using AdvoSecure.Infrastructure.Notifications.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub, INotificationHub> _hub;

        public NotificationController(IHubContext<NotificationHub, INotificationHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            await _hub.Clients.All.BroadcastTaskNotification(new TaskNotification { TaskName = "Test" });
            return Ok("Called");
        }
    }
}
