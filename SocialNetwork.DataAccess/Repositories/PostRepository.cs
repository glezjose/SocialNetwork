using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public class PostRepository : IBaseRepository<Post>, IPostRepository<Post>
    {
        protected readonly SocialNetworkContext context;

        public PostRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Add(Post post)
        {
            context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            context.Posts.Remove(post);
        }

        public IReadOnlyList<Post> GetFriendsPosts(int UserId)
        {
            return context.Users.Find(UserId).FriendsWith.SelectMany(fw => fw.FriendUser.Posts).OrderByDescending(p => p.Date).ToList();
        }

        public IReadOnlyList<Post> GetUserPosts(int UserId)
        {
            return context.Posts.Where(p => p.UserId == UserId).OrderByDescending(p => p.Date).ToList();
        }
    }
}
