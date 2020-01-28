using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
