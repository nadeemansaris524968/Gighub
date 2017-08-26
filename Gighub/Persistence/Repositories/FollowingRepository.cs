using System.Collections.Generic;
using System.Linq;
using Gighub.Core.Models;
using Gighub.Core.Repositories;

namespace Gighub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string gigArtistId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == gigArtistId);
        }

        public bool IsFollowing(string userId, string gigArtistId)
        {
            return _context.Followings
                .Any(f => f.FollowerId == userId && f.FolloweeId == gigArtistId);

        }

        public IEnumerable<ApplicationUser> GetArtistFollowings(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }

        public void CreateFollowing(Following following)
        {
            _context.Followings.Add(following);
        }

        public void RemoveFollowing(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}