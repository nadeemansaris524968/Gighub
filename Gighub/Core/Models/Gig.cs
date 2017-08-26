using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gighub.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public ApplicationUser Artist { get; set; }

        public string ArtistId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.GigCancelled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime updatedDateTime, string updatedVenue, byte updatedGenre)
        {
            //Setting notification for a specific Gig.
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            //Updating Gig with updated values from viewModel.
            DateTime = updatedDateTime;
            Venue = updatedVenue;
            GenreId = updatedGenre;

            //Setting UserNotifications for each attendee attending that Gig.
            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }
    }
}