using Gighub.Models;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult CreateFollowing()
        {

        }
    }
}
