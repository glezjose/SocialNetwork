using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Verification
{
    public class PhoneNumberVerifierFactory : VerifierFactory
    {
        private readonly IUserRepository<User> userRepository;

        public PhoneNumberVerifierFactory(IUserRepository<User> _userRepository)
        {
            userRepository = _userRepository;
        }
        protected override IVerifier MakeVerifier()
        {
            return new PhoneNumberVerifier(userRepository);
        }
    }
}
