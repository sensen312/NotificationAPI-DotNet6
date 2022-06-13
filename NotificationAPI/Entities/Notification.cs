using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationAPI.Entities
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NotificationId { get; set; }
        [Required]
        [MaxLength(255)]
        public String DeviceId { get; set; } = string.Empty; // string
        [Required]
        [MaxLength(255)]
        public String UserId { get; set; } = string.Empty; // string
        [Required]
        [MaxLength(255)]
        public string ApplicationName { get; set; } = string.Empty;
        public DateTime? SentDate { get; set; }
        public DateTime? RecievedDate { get; set; }

        //public Notification(Guid notificationId)
        //{
        //    NotificationId = notificationId;
        //}
    }
}
