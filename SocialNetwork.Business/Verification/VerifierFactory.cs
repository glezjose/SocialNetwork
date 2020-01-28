using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Verification
{
    public abstract class VerifierFactory : IVerifierFactory
    {
        public IVerifier CreateVerifier()
        {
            return this.MakeVerifier();
        }

        protected abstract IVerifier MakeVerifier();
    }
}
