using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.Models
{
    public class NotificationCreationDto
    {
        [Required]
        public Guid NotificationId { get; set; }
        [Required]
        public String DeviceId { get; set; } = string.Empty; // string
        [Required]
        public String UserId { get; set; } = string.Empty; // string
        public string ApplicationName { get; set; } = string.Empty;
   
    } 
}
