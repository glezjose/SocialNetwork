using SocialNetwork.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.PostHandling
{
    public abstract class PostHandler : IPostHandler
    {
        private IPostHandler postHandler;
        public void EvaluatePost(CompletePostDTO post)
        {
            if (!CreatePost(post))
            {
                postHandler?.EvaluatePost(post);
            }
        }

        public void SetNextPostType(IPostHandler postHandler)
        {
            this.postHandler = postHandler;
        }

        protected abstract bool CreatePost(CompletePostDTO post);

    }
}
