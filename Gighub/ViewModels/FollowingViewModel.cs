using System.Collections.Generic;
using Gighub.Models;

namespace Gighub.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Followees { get; set; }
        public string Title { get; set; }
    }
}