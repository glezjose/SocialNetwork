using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Multimedia { get; set; }
        public User User{ get; set; }
        public int UserId { get; set; }
    }
}
