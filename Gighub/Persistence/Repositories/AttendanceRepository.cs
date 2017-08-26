using System;
using System.Collections.Generic;
using System.Linq;
using Gighub.Core.Models;
using Gighub.Core.Repositories;

namespace Gighub.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public bool IsAttending(int id, string userId)
        {
            return _context.Attendances
                .Any(a => a.GigId == id && a.AttendeeId == userId);
        }

        public void CreateAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void RemoveAttendace(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }

        public Attendance GetAttendance(int gigId, string userId)
        {
            return _context.Attendances
                .SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == userId);
        }
    }
}