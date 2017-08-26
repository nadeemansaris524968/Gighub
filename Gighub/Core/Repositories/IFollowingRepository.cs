using System.Collections.Generic;
using Gighub.Core.Models;

namespace Gighub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string gigArtistId);
        bool IsFollowing(string userId, string gigArtistId);
        IEnumerable<ApplicationUser> GetArtistFollowings(string userId);
        void CreateFollowing(Following following);
        void RemoveFollowing(Following following);
    }
}