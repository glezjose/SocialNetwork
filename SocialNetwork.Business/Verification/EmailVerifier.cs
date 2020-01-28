﻿using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Verification
{
    public class EmailVerifier : IVerifier
    {
        private readonly IUserRepository<User> userRepository;

        public EmailVerifier(IUserRepository<User> _userRepository)
        {
            userRepository = _userRepository ?? throw new ArgumentNullException(nameof(_userRepository));
        }
        public bool Verify(string Email)
        {
            return userRepository.EmailNotExists(Email) ? false : true;
        }
    }
}
