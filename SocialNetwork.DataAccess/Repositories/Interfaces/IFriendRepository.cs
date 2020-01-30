using SocialNetwork.DataAccess.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IFriendRepository<T>: IBaseRepository<T>
    {
        void UpdateStatusRequest(T t);

       List<FriendRelationship> GetFriendRequests(int id);

        FriendRelationship GetFriendRelationshipByUsers(int UserId, int FriendUserId);

        bool FriendshipExists(int UserId, int FriendUserId);

    }
}
