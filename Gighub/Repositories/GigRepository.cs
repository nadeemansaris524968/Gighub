using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gighub.Models;

namespace Gighub.Repositories
{
    public class GigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == gigId);
        }

        public void CreateGig(Gig gig)
        {
            _context.Gigs.Add(gig);
            _context.SaveChanges();
        }

        public Gig GetGig(int id)
        {
            return _context.Gigs.SingleOrDefault(g => g.Id == id);
        }


        public Gig GetGigWithArtist(int id)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gig> GetMyUpcomingGigs(string userId)
        {
            return _context.Gigs
                .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && g.IsCancelled == false)
                .Include(g => g.Genre)
                .ToList();
        }
    }
}