using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IChatRepository
    {
        List<Chat> GetChat(int SenderId, int TargetId);
    }
}
