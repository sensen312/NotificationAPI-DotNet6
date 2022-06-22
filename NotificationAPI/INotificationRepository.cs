using NotificationAPI.Entities;

namespace NotificationAPI
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification notification);

        Task<int> UpdateNotificationAsync(Notification notification);
     
    }
}