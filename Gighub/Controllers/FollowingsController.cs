using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Gighub.Core;
using Gighub.Core.ViewModels;

namespace Gighub.Controllers
{
    [Authorize]
    public class FollowingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var followees = _unitOfWork.Followings.GetArtistFollowings(userId);

            var viewModel = new FollowingViewModel
            {
                Followees = followees,
                Title = "Artists I'm Following"
            };

            return View(viewModel);
        }
    }
}