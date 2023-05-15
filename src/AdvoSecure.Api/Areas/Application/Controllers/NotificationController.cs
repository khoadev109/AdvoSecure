using AdvoSecure.Application.Interfaces;
using AdvoSecure.Infrastructure.Notifications;
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
            return Ok("Called");
        }
    }
}
