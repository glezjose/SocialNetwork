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

        public Post GetById(int PostId)
        {
            return context.Posts.Find(PostId);
        }

        public IReadOnlyList<Post> GetFriendsPosts(int UserId)
        {
            //return context.Users.Find(UserId).FriendsWith.SelectMany(fw => fw.FriendUser.Posts).OrderByDescending(p => p.Date).ToList();
            return context.Users.Join(context.Friends, u => u.UserId, f => f.UserId, (u, f) => new User
            {
                UserId = f.FriendUserId
            }).Join(context.Posts, u => u.UserId, p => p.UserId, (u, p) => new Post
            {
                Title = p.Title,
                Description = p.Description,
                Date = p.Date,
            }).ToList();
        }

        public IReadOnlyList<Post> GetUserPosts(int UserId)
        {
            return context.Posts.Where(p => p.UserId == UserId).OrderByDescending(p => p.Date).ToList();
        }
    }
}
