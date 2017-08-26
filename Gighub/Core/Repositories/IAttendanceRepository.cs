using System.Collections.Generic;
using Gighub.Core.Models;

namespace Gighub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        bool IsAttending(int id, string userId);
        void CreateAttendance(Attendance attendance);
        void RemoveAttendace(Attendance attendance);
        Attendance GetAttendance(int gigId, string userId);
    }
}