using AdvoSecure.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace AdvoSecure.Infrastructure.Notifications
{
    public class NotificationHub : Hub<INotificationHub>
    {
        public string GetConnectionId() => Context.ConnectionId;
    }
}
