using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T t);
        T GetById(int id);
        void Delete(T t);
    }
}
