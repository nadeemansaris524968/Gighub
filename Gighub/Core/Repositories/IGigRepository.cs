using System.Collections.Generic;
using Gighub.Core.Models;

namespace Gighub.Core.Repositories
{
    public interface IGigRepository
    {
        void CreateGig(Gig gig);
        Gig GetGig(int id);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithArtist(int id);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetMyUpcomingGigs(string userId);
    }
}