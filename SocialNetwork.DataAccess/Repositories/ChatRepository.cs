using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public class ChatRepository : IBaseRepository<Chat>, IChatRepository
    {
        private readonly SocialNetworkContext context;

        public ChatRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Add(Chat chat)
        {
            context.Chats.Add(chat);
        }

        public void Delete(Chat chat)
        {
            context.Chats.Remove(chat);
        }

        public Chat GetById(int id)
        {
            return context.Chats.Find(id);
        }

        public List<Chat> GetChat(int SenderId, int TargetId)
        {
            return context.Chats
                .Where(c => (c.SenderUserId == SenderId && c.TargetUserId == TargetId) 
                && (c.SenderUserId == TargetId && c.TargetUserId == SenderId))
                .ToList();
        }
    }
}
