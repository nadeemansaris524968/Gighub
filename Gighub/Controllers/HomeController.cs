using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Gighub.Core.ViewModels;
using Gighub.Persistence;
using Gighub.Persistence.Repositories;
using Microsoft.AspNet.Identity;

namespace Gighub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private AttendanceRepository _attendanceRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _attendanceRepository = new AttendanceRepository(_context);
        }
        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && g.IsCancelled == false)
                .ToList();

            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingGigs = upcomingGigs
                    .Where(g => 
                            g.Artist.Name.Contains(query) || 
                            g.Venue.Contains(query) || 
                            g.Genre.Name.Contains(query))
                            .ToList();
            }

            string userId = User.Identity.GetUserId();

            var attendances = _attendanceRepository.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Title = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}