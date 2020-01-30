using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.BusinessLogic.Services;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.API.Controllers
{
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService _friendService)
        {
            friendService = _friendService ?? throw new ArgumentNullException(nameof(_friendService));
        }

        [HttpGet()]
        [Route("api/user/{id}/requests")]
        public IActionResult GetFriendRequests(int id)
        {
            List<FriendRequestDTO> friendRequests = friendService.GetFriendRequests(id);

            if (!friendRequests.Any()) return NotFound();


            return Ok(friendRequests);
        }

        [HttpPost]
        [Route("api/user/{id}/friend")]
        public IActionResult AddFriend(int id, FriendRelationship friendRelationship)
        {
            try
            {
                friendRelationship.UserId = id;
                FriendRequestAddedDTO friendRequest = friendService.AddFriend(friendRelationship);

                if (friendRequest == null) return NotFound("La amistad entre los usuarios ya existe.");

                return Ok(friendRequest);
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("api/user/{id}/friend")]
        public IActionResult UpdateFriendRequest(int id, FriendToAddDTO friend)
        {
            try
            {
                friend.UserId = id;
                FriendRequestDTO friendRequest = friendService.UpdateRequestStatus(friend);

                return Ok(friendRequest);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("api/user/{id}/friend")]
        public IActionResult DeleteFriend(int id, FriendToAddDTO friend)
        {
            try
            {
                friend.UserId = id;
                friendService.DeleteFriend(friend);
                return NoContent();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}