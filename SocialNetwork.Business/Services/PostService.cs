using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialNetwork.BusinessLogic.CloudinaryServices;
using SocialNetwork.BusinessLogic.PostHandling;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;
using System;
using System.Collections.Generic;

namespace SocialNetwork.BusinessLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICloudinaryService cloudinary;

        public PostService(IPostRepository<Post> _postRepository, IUnitOfWork _unitOfWork, IMapper _mapper, ICloudinaryService cloudinary)
        {
            postRepository = _postRepository ?? throw new ArgumentNullException(nameof(_postRepository));
            unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this.cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }

        public PostDTO AddPost(IFormFile file, Post post)
        {
            CompletePostDTO completePost = new CompletePostDTO()
            {
                FileInPost = file,
                Post = post
            };

            IPostHandler textPost = new PostText(postRepository, unitOfWork);
            IPostHandler imagePost = new PostImage(postRepository, unitOfWork, cloudinary);
            IPostHandler videoPost = new PostVideo(postRepository, unitOfWork, cloudinary);

            textPost.SetNextPostType(imagePost);
            imagePost.SetNextPostType(videoPost);

            textPost.EvaluatePost(completePost);

            return mapper.Map<PostDTO>(post);
        }

        public List<PostDTO> GetUserPosts(int id)
        {
            return postRepository.GetUserPosts(id).ConvertAll(mapper.Map<PostDTO>);
        }

        public List<PostDTO> GetFriendsFeed(int id)
        {
            return postRepository.GetFriendsPosts(id).ConvertAll(mapper.Map<PostDTO>);
        }
    }
}
