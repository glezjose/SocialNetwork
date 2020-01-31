using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DataAccess.Repositories
{
    public class FriendRepository : IFriendRepository<FriendRelationship>
    {
        private readonly SocialNetworkContext context;
        public FriendRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Add(FriendRelationship friend)
        {
            context.Friends.Add(friend);
            context.Entry(friend).Reference("FriendUser").Load();
        }

        public void Delete(FriendRelationship friend)
        {
            context.Friends.Remove(friend);
        }

        public FriendRelationship GetById(int id)
        {
            return context.Friends.Find(id);
        }

        public void UpdateStatusRequest(FriendRelationship friend)
        {
            context.Entry(friend).Property("IsAccepted").IsModified = true;
            
        }

        public List<FriendRelationship> GetFriendRequests(int id)
        {
            return context.Friends.AsNoTracking().Where(f => f.FriendUserId == id && f.IsAccepted == false).Include(u => u.User).ToList();
        }

        public FriendRelationship GetFriendRelationshipByUsers(int UserId, int FriendUserId)
        {
            return context.Friends.AsNoTracking().Include(f => f.User).FirstOrDefault(f => f.UserId == UserId && f.FriendUserId == FriendUserId);
        }

        public bool FriendshipExists(int UserId, int FriendUserId)
        {
            return !context.Friends.AsNoTracking().Any(f =>
            (f.UserId == UserId && f.FriendUserId == FriendUserId) ||
            (f.FriendUserId == UserId && f.UserId == FriendUserId));
        }
    }
}
