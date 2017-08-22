﻿using System.Data.Entity;
using Gighub.Dtos;
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
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.GigId == dto.GigId && a.AttendeeId == userId))
                return BadRequest("Attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _context.Attendances.SingleOrDefault(a => a.AttendeeId == userId & a.GigId == id);
            if (attendance == null)
                return BadRequest();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
