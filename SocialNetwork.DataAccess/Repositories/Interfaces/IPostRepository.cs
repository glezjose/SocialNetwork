using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IPostRepository<T>
    {
        IReadOnlyList<T> GetFriendsPosts(int UserId);

        IReadOnlyList<T> GetUserPosts(int UserId);
    }
}
