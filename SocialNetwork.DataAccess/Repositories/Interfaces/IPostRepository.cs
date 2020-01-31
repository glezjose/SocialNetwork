using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IPostRepository<T>: IBaseRepository<T>
    {
        List<T> GetFriendsPosts(int UserId);

        List<T> GetUserPosts(int UserId);
    }
}
