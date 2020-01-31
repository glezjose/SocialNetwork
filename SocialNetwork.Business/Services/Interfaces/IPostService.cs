using Microsoft.AspNetCore.Http;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System.Collections.Generic;

namespace SocialNetwork.BusinessLogic.Services
{
    public interface IPostService
    {
        PostDTO AddPost(IFormFile file, Post post);
        List<PostDTO> GetUserPosts(int id);
        List<PostDTO> GetFriendsFeed(int id);
    }
}