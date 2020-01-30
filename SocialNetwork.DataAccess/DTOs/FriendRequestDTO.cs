using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.DTOs
{
    public class FriendRequestDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string RequestStatus { get; set; }
    }
}
