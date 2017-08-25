using System.Collections.Generic;
using Gighub.Models;

namespace Gighub.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        bool IsAttending(int id, string userId);
    }
}