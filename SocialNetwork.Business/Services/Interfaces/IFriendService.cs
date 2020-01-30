using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System.Collections.Generic;

namespace SocialNetwork.BusinessLogic.Services
{
    public interface IFriendService
    {
        FriendRequestAddedDTO AddFriend(FriendRelationship friendRelationship);
        List<FriendRequestDTO> GetFriendRequests(int id);
        FriendRequestDTO UpdateRequestStatus(FriendToAddDTO friendRelationship);
        void DeleteFriend(FriendToAddDTO friend);
    }
}