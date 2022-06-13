using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.Models
{
    public class NotificationUpdateDto
    {
        [Required]
        public Guid NotificationId { get; set; }

    }
}
