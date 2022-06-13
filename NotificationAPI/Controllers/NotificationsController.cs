using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationAPI.Entities;
using NotificationAPI.Models;

namespace NotificationAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class NotificationsController : ControllerBase
    {
        private readonly ILogger<NotificationsController> logger;
        private INotificationRepository notificationRepository;
        public NotificationsController(INotificationRepository notificationRepository, ILogger<NotificationsController> logger)
        {
            this.notificationRepository = notificationRepository;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost]
        public async Task<ActionResult<NotificationDto>> CreateNotification([FromBody] NotificationCreationDto notification)
        {
            try
            {
                // create date date.UTCNow
                // 
                // for now I could create a new List
                DateTime sentDate = DateTime.UtcNow;

                // ADD MAPPER?
                // Im not sure if this is how this works but is this basically the mapper? do I have to map it back to the DTO
                var createdNotification = new Notification()
                {
                    NotificationId = notification.NotificationId,
                    DeviceId = notification.DeviceId,
                    UserId = notification.UserId,
                    ApplicationName = notification.ApplicationName,
                    SentDate = sentDate
                };

                // NotificationsDataStore.Current.Notifications.Add(createdNotification); // some brain code
                // Look I'm not going to lie I am just guessing at this point
                // How do I save to Async?
                await this.notificationRepository.AddNotificationAsync(createdNotification);

                // Logging Every Time a Notification is Created
                this.logger.LogInformation($"Notification with Id {notification.NotificationId} was created");

                return Created($"/api/Notifications/{notification.NotificationId}", createdNotification); // save it to a database
            }
            catch (Exception ex)
            {
                this.logger.LogCritical(
                    $"Exception occured trying to create {notification.NotificationId}.",
                    ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<NotificationDto>> UpdateNotification([FromBody] NotificationUpdateDto notification)
        {
            try
            {
                // Creating the date the notification was recieved
                DateTime recievedDate = DateTime.UtcNow;

                // mapping I think
                var updatedNotification = new Notification()
                {
                    NotificationId = notification.NotificationId,
                    RecievedDate = recievedDate
                };

                // Handles if there is no notification to update.
                if (await this.notificationRepository.UpdateNotificationAsync(updatedNotification) == 0)
                {
                    this.logger.LogWarning($"Notification with Id {notification.NotificationId} was Not Found!");
                    return NotFound();
                }
                // update logger
                this.logger.LogInformation($"Notification with Id {notification.NotificationId} was updated");
                return NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogCritical(
                    $"Exception occured trying to update {notification.NotificationId}.",
                    ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

    }
}
