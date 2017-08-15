using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateFollowing(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (dto.FolloweeId == userId)
                return BadRequest();

            if (_context.Followings.Any(f => f.FolloweeId == dto.FolloweeId && f.FollowerId == userId))
                return BadRequest("Following already exists");

            Following following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
