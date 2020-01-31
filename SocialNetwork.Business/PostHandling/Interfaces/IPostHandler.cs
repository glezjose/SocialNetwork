using SocialNetwork.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.PostHandling
{
    public interface IPostHandler
    {
        void SetNextPostType(IPostHandler postHandler);
        void EvaluatePost(CompletePostDTO post);
    }
}
