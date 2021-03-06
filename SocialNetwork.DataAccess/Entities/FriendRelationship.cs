﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Entities
{
    public class FriendRelationship
    {
        public int FriendRelationshipId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public User FriendUser { get; set; }
        public int FriendUserId { get; set; }

        public bool IsAccepted { get; set; }
    }
}
