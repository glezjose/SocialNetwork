using FluentValidation;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Validations
{
    public class FriendRelationshipValidator : AbstractValidator<FriendRelationship>
    {
        public FriendRelationshipValidator()
        {
            RuleFor(f => f.FriendUserId).NotEmpty().WithMessage("Por favor introduzca un usuario a quien agregar.");
        }
    }
}
