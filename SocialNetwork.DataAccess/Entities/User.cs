using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string MotherSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual List<Friend> FriendsWith { get; set; }
        public virtual List<Friend> FriendsOf { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Chat> SentMessages { get; set; }
        public virtual List<Chat> RecievedMessages { get; set; }
    }
}
