using AutoMapper;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.PostHandling
{
    public class PostText : PostHandler
    {
        private readonly IPostRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostText(IPostRepository<Post> postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        protected override bool CreatePost(CompletePostDTO post)
        {

            if (post.FileInPost == null || post.FileInPost.Length == 0)
            {
                postRepository.Add(post.Post);
                unitOfWork.Commit();

                return true;
            }
            else return false;
        }
    }
}
