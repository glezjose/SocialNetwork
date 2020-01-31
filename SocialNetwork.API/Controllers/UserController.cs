using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BusinessLogic.Services;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            UserDTO user = userService.GetUser(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<UserDTO> users = userService.GetUsers();

            if (!users.Any()) return NotFound();

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