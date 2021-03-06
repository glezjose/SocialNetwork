﻿using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public interface IUserRepository<T>: IBaseRepository<T>
    {
        void Update(User user);

        List<User> GetFriends(int UserId);

        List<User> GetAllUsers();

        bool EmailNotExists(string Email);

        bool PhoneNumberNotExists(string PhoneNumber);
    }
}
