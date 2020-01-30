using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System.Collections.Generic;

namespace SocialNetwork.BusinessLogic.Services
{
    public interface IUserService
    {
        UserDTO GetUser(int UserId);
        List<UserDTO> GetUsers();
        UserDTO AddUser(User user);
    }
}