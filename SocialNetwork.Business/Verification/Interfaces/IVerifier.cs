using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Verification
{
    public interface IVerifier
    {
        bool Verify(string verifyString);
    }
}
