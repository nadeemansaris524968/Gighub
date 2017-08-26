using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Gighub.Core.Dtos;
using Gighub.Core.Models;
using Gighub.Persistence;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            string userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(u => u.UserId == userId && u.IsRead == false)
                .Select(u => u.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkNotificationsAsRead()
        {
            var userId = User.Identity.GetUserId();

            var userNotifications = _context.UserNotifications
                .Where(un => un.UserId == userId && un.IsRead == false)
                .ToList();

            userNotifications.ForEach(un => un.Read());

            _context.SaveChanges();

            return Ok();
        }
    }
}
