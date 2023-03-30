using AdvoSecure.Infrastructure.Notifications.Model;

namespace AdvoSecure.Infrastructure.Notifications
{
    public interface INotificationHub
    {
        Task BroadcastMessage();

        Task BroadcastTaskNotification(TaskNotification task);
    }
}
