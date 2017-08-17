﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gighub.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public ApplicationUser User { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public Notification Notification { get; private set; }

        public bool IsRead { get; set; }


        public UserNotification(ApplicationUser user, Notification notification)
        {
            // ReSharper disable once JoinNullCheckWithUsage
            if (user == null)
                // ReSharper disable once UseNameofExpression
                throw new ArgumentNullException("user");

            // ReSharper disable once JoinNullCheckWithUsage
            if (notification == null)
                // ReSharper disable once UseNameofExpression
                throw new ArgumentNullException("notification");

            User = user;
            Notification = notification;
        }

        protected UserNotification()
        {
        }
    }
}