﻿using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Gighub.Core;
using Gighub.Persistence;

namespace Gighub.Controllers.Api
{
    [System.Web.Http.Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            string userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig.ArtistId != userId)
                return Unauthorized();

            if (gig != null && gig.IsCancelled)
                return NotFound();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
