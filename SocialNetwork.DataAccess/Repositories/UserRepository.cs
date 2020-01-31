using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly SocialNetworkContext context;
        public UserRepository(SocialNetworkContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }
        public User GetById(int UserId)
        {
            return context.Users.Find(UserId);
        }

        public List<User> GetFriends(int UserId)
        {
            return context.Users.Find(UserId).FriendsWith.FindAll(f => f.UserId == UserId).Select(f => f.FriendUser).ToList();
        }
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public bool EmailNotExists(string Email)
        {
            return !context.Users.AsNoTracking().Any(u => u.Email == Email);
        }

        public bool PhoneNumberNotExists(string PhoneNumber)
        {
            return !context.Users.AsNoTracking().Any(u => u.PhoneNumber == PhoneNumber);
        }
    }
}
