using System.Collections.Generic;
using Gighub.Core.Models;

namespace Gighub.Core.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Followees { get; set; }
        public string Title { get; set; }
    }
}