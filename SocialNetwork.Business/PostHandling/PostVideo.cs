using SocialNetwork.BusinessLogic.CloudinaryServices;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.PostHandling
{
    public class PostVideo: PostHandler
    {
        private readonly IPostRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICloudinaryService cloudinary;

        public PostVideo(IPostRepository<Post> postRepository, IUnitOfWork unitOfWork, ICloudinaryService cloudinary)
        {
            this.postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }
        protected override bool CreatePost(CompletePostDTO post)
        {

            if (post.FileInPost.ContentType.Equals("video/mp4", StringComparison.OrdinalIgnoreCase) ||
                post.FileInPost.ContentType.Equals("video/avi", StringComparison.OrdinalIgnoreCase))
            {
                string multimedia = cloudinary.VideoUpload(post.FileInPost);

                post.Post.Multimedia = multimedia;
                postRepository.Add(post.Post);
                unitOfWork.Commit();

                return true;
            }
            else return false;
        }
    }
}
