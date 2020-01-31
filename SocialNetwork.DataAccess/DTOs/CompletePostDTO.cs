using Microsoft.AspNetCore.Http;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.DTOs
{
    public class CompletePostDTO
    {
        public IFormFile FileInPost { get; set; }
        public Post Post { get; set; }
    }
}
