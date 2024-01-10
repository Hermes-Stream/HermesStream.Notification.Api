using HermesStream.Notification.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HermesStream.Notification.Api.Controllers
{
    [Route("notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet]
        [Route("get-notification-InformationType")]
        public ActionResult GetOneNotificationInformation()
        {
            try
            {
                var dto = _notificationService.GetOneTypeInformation();

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("populate-notifications")]
        public ActionResult PopulateNotifications()
        {
            try
            {
                var populate = _notificationService.PopulateNotifications();

                return Ok(populate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
