using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody]int gigId)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.GigId == gigId && a.AttendeeId == userId))
                return BadRequest("Attendance already exists.");

            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
