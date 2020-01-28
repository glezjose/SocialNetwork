using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BusinessLogic.Services;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService ?? throw new ArgumentNullException(nameof(_userService));
        }

        [HttpGet("{UserId}")]
        public IActionResult GetUser(int UserId)
        {
            UserDTO user = userService.GetUser(UserId);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<UserDTO> users = userService.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult NewUser(User user)
        {
            UserDTO newUser = userService.AddUser(user);

            return Ok(newUser);
        }
    }
}