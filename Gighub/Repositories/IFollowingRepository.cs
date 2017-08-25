namespace Gighub.Repositories
{
    public interface IFollowingRepository
    {
        bool IsFollowing(string userId, string gigArtistId);
    }
}