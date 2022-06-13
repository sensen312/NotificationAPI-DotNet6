using NotificationAPI.Entities;

namespace NotificationAPI
{
    public interface INotificationRepository
    {
     //   Task FindNotification(Guid NotificationId);
        Task AddNotificationAsync(Notification notification);

        Task<int> UpdateNotificationAsync(Notification notification);
     
    }
}