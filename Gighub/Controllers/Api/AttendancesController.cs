using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using Gighub.Core;
using Gighub.Core.Dtos;
using Gighub.Core.Models;
using Gighub.Persistence;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Attendances.IsAttending(dto.GigId, userId))
                return BadRequest("Attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _unitOfWork.Attendances.CreateAttendance(attendance);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(id, userId);
            if (attendance == null)
                return BadRequest();

            _unitOfWork.Attendances.RemoveAttendace(attendance);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
