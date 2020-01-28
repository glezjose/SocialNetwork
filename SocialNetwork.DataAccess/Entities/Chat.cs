using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Entities
{
    public class Chat
    {
        public int ChatId { get; set; }

        public User SenderUser { get; set; }
        public int SenderUserId { get; set; }

        public Message Message { get; set; }
        public int MessageId { get; set; }

        public User TargetUser { get; set; }
        public int TargetUserId { get; set; }

        public DateTime Date { get; set; }
    }
}
