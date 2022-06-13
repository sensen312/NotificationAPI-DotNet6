using NotificationAPI.Models;

namespace NotificationAPI
{
    public class NotificationsDataStore
    {
        
        public List<NotificationDto> Notifications { get; set; }

        // singleton pattern network?
        public static NotificationsDataStore Current { get; } = new NotificationsDataStore();
        
        // dummy data
        public NotificationsDataStore()
        {
            Notifications = new List<NotificationDto>()
            {
                new NotificationDto()
                {
                    NotificationId = new Guid(),
                    DeviceId = " ",
                    UserId = " ", 
                    ApplicationName = "App1",
                   // RecievedDate = DateTime.Today,
                   // Date = new DateTime(2022, 6, 8)

                    
                }
            };
        }

    }
}
