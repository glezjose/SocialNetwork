using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageToSend { get; set; }

        public Chat Chat { get; set; }
    }
}
