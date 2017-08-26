using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Gighub.Core.ViewModels;
using Gighub.Persistence;

namespace Gighub.Controllers
{
    [Authorize]
    public class FollowingsController : Controller
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var followees = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            var viewModel = new FollowingViewModel
            {
                Followees = followees,
                Title = "Artists I'm Following"
            };

            return View(viewModel);
        }
    }
}