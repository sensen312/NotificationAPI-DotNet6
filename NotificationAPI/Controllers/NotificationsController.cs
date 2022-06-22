using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationAPI.Entities;
using NotificationAPI.Models;

namespace NotificationAPI.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly ILogger<NotificationsController> logger;
        private INotificationRepository notificationRepository;
        public NotificationsController(INotificationRepository notificationRepository, ILogger<NotificationsController> logger)
        {
            this.notificationRepository = notificationRepository;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Stores Notification Sent Date
        /// </summary>
        /// <param name="notification">Json object notification</param>
        /// <returns>ActionResult<NotificationDto></returns>
        [HttpPost]
        public async Task<ActionResult<NotificationDto>> CreateNotification([FromBody] NotificationCreationDto notification)
        {
            try
            {
                // creates date date.UTCNow
                DateTime sentDate = DateTime.UtcNow;

                var createdNotification = new Notification()
                {
                    NotificationId = notification.NotificationId,
                    DeviceId = notification.DeviceId,
                    UserId = notification.UserId,
                    ApplicationName = notification.ApplicationName,
                    SentDate = sentDate
                };

                await this.notificationRepository.AddNotificationAsync(createdNotification);

                // Logging Every Time a Notification is Created
                this.logger.LogInformation($"Notification with Id {notification.NotificationId} was created");

                return Created($"/api/Notifications/{notification.NotificationId}", createdNotification);
            }
            catch (Exception ex)
            {
                this.logger.LogError(
                   $"Exception occured trying to create {notification.NotificationId}.",
                   ex);
                return StatusCode(500, "A problem happened while handling your request");
            }

        }
        
        /// <summary>
        /// Stores Notification Receive Date
        /// </summary>
        /// <param name="notificationId">Id of Notification</param>
        /// <returns>ActionResult<NotificationDto></returns>
        [HttpPut("{notificationId}")]
        public async Task<ActionResult<NotificationDto>> UpdateNotification( Guid notificationId)
        {
            try
            {
                DateTime recievedDate = DateTime.UtcNow;

                var updatedNotification = new Notification()
                {
                    NotificationId = notificationId,
                    RecievedDate = recievedDate
                };

                // Handles if there is no notification to update.
                if (await this.notificationRepository.UpdateNotificationAsync(updatedNotification) == 0)
                {
                    this.logger.LogWarning($"Notification with Id {notificationId} was Not Found!");
                    return NotFound();
                }
                // Updates logger
                this.logger.LogInformation($"Notification with Id {notificationId} was updated");
                return NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(
                    $"Exception occured trying to update {notificationId}.",
                    ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

    }
}
