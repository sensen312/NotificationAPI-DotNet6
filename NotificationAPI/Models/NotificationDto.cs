using System.ComponentModel.DataAnnotations;


namespace NotificationAPI.Models
{
    public class NotificationDto
    {
        /// <summary>
        /// Id of notification
        /// </summary>
        [Required]
        public Guid NotificationId { get; set; }

        /// <summary>
        /// Id of Device
        /// </summary>
        [Required]
        public String DeviceId { get; set; } = string.Empty;

        /// <summary>
        /// Id of User
        /// </summary>
        [Required]
        public String UserId { get; set; } = string.Empty;

        /// <summary>
        /// Id of Application
        /// </summary>
        public string ApplicationName { get; set; } = string.Empty;


    }
}
