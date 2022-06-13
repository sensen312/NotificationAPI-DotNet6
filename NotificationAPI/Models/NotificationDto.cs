namespace NotificationAPI.Models
{
    public class NotificationDto
    {
        public Guid NotificationId { get; set; }
        public String DeviceId { get; set; } = string.Empty; // string
        public String UserId { get; set; } = string.Empty; // string
        public string ApplicationName { get; set; } = string.Empty;


    }
}
