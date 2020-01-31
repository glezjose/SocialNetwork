using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DataAccess.Repositories
{
    public class PostRepository : IPostRepository<Post>
    {
        protected readonly SocialNetworkContext context;

        public PostRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Add(Post post)
        {
            context.Posts.Add(post);
            context.Entry(post).Reference("User").Load();
        }

        public void Delete(Post post)
        {
            context.Posts.Remove(post);
        }

        public Post GetById(int PostId)
        {
            return context.Posts.Find(PostId);
        }

        public List<Post> GetFriendsPosts(int UserId)
        {
            return context.Users.AsNoTracking()
                .Join(context.Friends,
                user => user.UserId,
                friend => friend.UserId,
                (user, friend) => new { user, friend })
                .Join(context.Posts,
                newfriend => newfriend.friend.FriendUserId,
                post => post.UserId,
                (newfriend, post) => new { newfriend, post })
                .Where(f => f.newfriend.friend.UserId == UserId)
                .Select(p => new Post
                {
                    Title = p.post.Title,
                    Description = p.post.Description,
                    Multimedia = p.post.Multimedia,
                    Date = p.post.Date,
                    User = p.post.User
                }).ToList();
        }

        public List<Post> GetUserPosts(int UserId)
        {
            return context.Posts.AsNoTracking().Include(p => p.User).Where(p => p.UserId == UserId).OrderByDescending(p => p.Date).ToList();
        }
    }
}
