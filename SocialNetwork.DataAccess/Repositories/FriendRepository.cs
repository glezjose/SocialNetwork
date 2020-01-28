using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public class FriendRepository : IBaseRepository<Friend>, IFriendRepository<Friend>
    {
        protected readonly SocialNetworkContext context;
        public FriendRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Add(Friend friend)
        {
            context.Friends.Add(friend);
        }

        public void Delete(Friend friend)
        {
            context.Friends.Remove(friend);
        }

        public void UpdateStatusRequest(Friend friend)
        {
            context.Entry(friend).Property("IsAccepted").IsModified = true;
        }
    }
}
