using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;

namespace SocialNetwork.BusinessLogic.Verification
{
    public class EmailVerifierFactory : VerifierFactory
    {
        private readonly IUserRepository<User> userRepository;

        public EmailVerifierFactory(IUserRepository<User> _userRepository)
        {
            userRepository = _userRepository;
        }
        protected override IVerifier MakeVerifier()
        {
            return new EmailVerifier(userRepository);
        }
    }
}
