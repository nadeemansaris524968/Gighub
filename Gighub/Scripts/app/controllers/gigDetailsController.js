var GigDetailsController = function(followingService) {
    var followButton;

    var init = function() {
        $(".js-toggle-follow").click(toggleFollow);
    };
    var toggleFollow = function(e) {
        followButton = $(e.target);
        var followeeId = followButton.attr("data-user-id");

        if (followButton.hasClass("btn-default")) {
            followingService.follow(followeeId, done, fail);
        } else {
            followingService.unfollow(followeeId, done, fail);
        }
    };
    var done = function() {
        var text = (followButton.text() == "Following") ? "Follow" : "Following";
        followButton.toggleClass("btn-default").toggleClass("btn-info").text(text);
    };
    var fail = function() {
        alert("Something went wrong :(");
    };

    return {
        init: init
    }
}(FollowingService);
