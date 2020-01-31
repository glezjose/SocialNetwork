using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.DTOs
{
    public class FriendToAddDTO
    {
        public int FriendId { get; set; }
        public int UserId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
