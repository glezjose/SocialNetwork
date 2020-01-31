using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.DTOs
{
    public class FriendRequestAddedDTO
    {
        public int FriendUserId { get; set; }
        public string Name { get; set; }
        public string RequestStatus { get; set; }
    }
}
