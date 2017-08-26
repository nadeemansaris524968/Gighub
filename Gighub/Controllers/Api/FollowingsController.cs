using Microsoft.AspNet.Identity;
using System.Web.Http;
using Gighub.Core;
using Gighub.Core.Dtos;
using Gighub.Core.Models;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult CreateFollowing(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Followings.IsFollowing(userId, dto.FolloweeId))
                return BadRequest("Following already exists");

            Following following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };
            _unitOfWork.Followings.CreateFollowing(following);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(userId, id);

            if (following == null)
                return NotFound();

            _unitOfWork.Followings.RemoveFollowing(following);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
