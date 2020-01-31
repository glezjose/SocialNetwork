using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.DTOs
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Multimedia { get; set; }
        public DateTime DatePosted { get; set; }
        public string PostedBy { get; set; }
    }
}
