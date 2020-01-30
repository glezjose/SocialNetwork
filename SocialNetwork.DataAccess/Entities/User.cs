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
        public virtual List<FriendRelationship> FriendsWith { get; }
        public virtual List<FriendRelationship> FriendsOf { get; }
        public virtual List<Post> Posts { get; }
        public virtual List<Chat> SentMessages { get; }
        public virtual List<Chat> RecievedMessages { get; }
    }
}
