using System.Collections.Generic;
using Gighub.Core.Models;

namespace Gighub.Core.Repositories
{
    public interface IFollowingRepository
    {
        bool IsFollowing(string userId, string gigArtistId);
        IEnumerable<ApplicationUser> GetArtistFollowings(string userId);
    }
}