using SocialNetwork.BusinessLogic.CloudinaryServices;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;
using System;

namespace SocialNetwork.BusinessLogic.PostHandling
{
    public class PostImage : PostHandler
    {
        private readonly IPostRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICloudinaryService cloudinary;

        public PostImage(IPostRepository<Post> postRepository, IUnitOfWork unitOfWork, ICloudinaryService cloudinary)
        {
            this.postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }
        protected override bool CreatePost(CompletePostDTO post)
        {

            if (post.FileInPost.ContentType.Equals("image/jpg", StringComparison.OrdinalIgnoreCase) || 
                post.FileInPost.ContentType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase) ||
                post.FileInPost.ContentType.Equals("image/png", StringComparison.OrdinalIgnoreCase) ||
                post.FileInPost.ContentType.Equals("image/gif", StringComparison.OrdinalIgnoreCase))
            {
                string multimedia = cloudinary.ImageUpload(post.FileInPost);

                post.Post.Multimedia = multimedia;
                postRepository.Add(post.Post);
                unitOfWork.Commit();

                return true;
            }
            else return false;
        }
    }
}
