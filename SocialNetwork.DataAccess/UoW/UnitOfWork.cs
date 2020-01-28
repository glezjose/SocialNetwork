using SocialNetwork.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly SocialNetworkContext context;

        public UnitOfWork(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
