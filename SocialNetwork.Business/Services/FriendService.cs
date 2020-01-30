using AutoMapper;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;
using System;
using System.Collections.Generic;

namespace SocialNetwork.BusinessLogic.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository<FriendRelationship> friendRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FriendService(IFriendRepository<FriendRelationship> _friendRepository, IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            friendRepository = _friendRepository ?? throw new ArgumentNullException(nameof(_friendRepository));
            unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public List<FriendRequestDTO> GetFriendRequests(int id)
        {
            return friendRepository.GetFriendRequests(id).ConvertAll(mapper.Map<FriendRequestDTO>);
        }

        public FriendRequestAddedDTO AddFriend(FriendRelationship friendRelationship)
        {
            if (friendRepository.FriendshipExists(friendRelationship.UserId, friendRelationship.FriendUserId))
            {
                friendRepository.Add(friendRelationship);
                unitOfWork.Commit();

                return mapper.Map<FriendRequestAddedDTO>(friendRelationship);
            }
            else return null;
        }

        public FriendRequestDTO UpdateRequestStatus(FriendToAddDTO friend)
        {
            FriendRelationship friendRelationship = friendRepository.GetFriendRelationshipByUsers(friend.FriendId, friend.UserId);
            friendRelationship.IsAccepted = friend.IsAccepted;

            friendRepository.UpdateStatusRequest(friendRelationship);
            unitOfWork.Commit();

            return mapper.Map<FriendRequestDTO>(friendRelationship);
        }

        public void DeleteFriend(FriendToAddDTO friend)
        {
            FriendRelationship friendRelationship = friendRepository.GetFriendRelationshipByUsers(friend.FriendId, friend.UserId);
            if(friendRelationship == null)
            {
                friendRelationship = friendRepository.GetFriendRelationshipByUsers(friend.UserId, friend.FriendId);
            }

            friendRepository.Delete(friendRelationship);
            unitOfWork.Commit();
        }
    }
}
