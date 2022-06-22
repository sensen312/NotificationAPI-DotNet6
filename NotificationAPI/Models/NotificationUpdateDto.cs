using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.Models
{
    public class NotificationUpdateDto
    {
        /// <summary>
        /// Id of notification
        /// </summary>
        [Required]
        public Guid NotificationId { get; set; }

    } 
}
