namespace Gighub.Core.Repositories
{
    public interface IFollowingRepository
    {
        bool IsFollowing(string userId, string gigArtistId);
    }
}