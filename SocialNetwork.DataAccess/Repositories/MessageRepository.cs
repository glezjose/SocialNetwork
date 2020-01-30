using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public class MessageRepository : IBaseRepository<Message>
    {
        protected readonly SocialNetworkContext context;

        public MessageRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Add(Message message)
        {
            context.Messages.Add(message);
        }

        public void Delete(Message message)
        {
            context.Messages.Remove(message);
        }

        public Message GetById(int id)
        {
            return context.Messages.Find(id);
        }
    }
}
