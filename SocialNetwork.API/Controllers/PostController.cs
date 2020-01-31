using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocialNetwork.BusinessLogic.Services;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.API.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }

        [HttpGet]
        [Route("api/user/{id}/post")]
        public IActionResult GetPosts(int id)
        {
            List<PostDTO> posts = postService.GetUserPosts(id);

            if (!posts.Any()) return NotFound();

            return Ok(posts);
        }

        [HttpGet]
        [Route("api/user/{id}/feed")]
        public IActionResult GetFeed(int id)
        {
            List<PostDTO> posts = postService.GetFriendsFeed(id);

            if (!posts.Any()) return NotFound();

            return Ok(posts);
        }

        [HttpPost]
        [Route("api/user/{id}/post")]
        public IActionResult AddPost(int id, [FromForm]IFormFile file)
        {
            try
            {
                Post post = JsonConvert.DeserializeObject<Post>(Request.Form.FirstOrDefault(p => p.Key == "post").Value);
                post.UserId = id;
                PostDTO postDTO = postService.AddPost(file, post);

                return Ok(postDTO);
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
        }
    }
}