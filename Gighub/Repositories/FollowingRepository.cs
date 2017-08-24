using System.Linq;
using Gighub.Models;

namespace Gighub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsFollowing(string userId, string gigArtistId)
        {
            return _context.Followings
                .Any(f => f.FollowerId == userId && f.FolloweeId == gigArtistId);

        }
    }
}