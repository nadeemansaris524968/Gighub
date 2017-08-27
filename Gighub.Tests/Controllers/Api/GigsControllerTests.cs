using System.Web.Http.Results;
using FluentAssertions;
using Gighub.Controllers.Api;
using Gighub.Core;
using Gighub.Core.Models;
using Gighub.Core.Repositories;
using Gighub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gighub.Tests.Controllers.Api
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;
        private Mock<IGigRepository> _mockRepository;

        public GigsControllerTests()
        {
            _mockRepository = new Mock<IGigRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Gigs).Returns(_mockRepository.Object);

            _controller = new GigsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com");
        }

        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_GigIsCancelled_ShouldReturnNotFound()
        {
            var gig = new Gig();
            gig.Cancel();

            _mockRepository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

    }
}
