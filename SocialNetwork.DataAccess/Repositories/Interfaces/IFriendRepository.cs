using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IFriendRepository<T>
    {
        void UpdateStatusRequest(T t);
    }
}
