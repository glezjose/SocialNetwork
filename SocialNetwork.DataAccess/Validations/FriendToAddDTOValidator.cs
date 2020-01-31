using FluentValidation;
using SocialNetwork.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Validations
{
    public class FriendToAddDTOValidator: AbstractValidator<FriendToAddDTO>
    {
        public FriendToAddDTOValidator()
        {
            RuleFor(f => f.FriendId).NotEmpty().WithMessage("Por favor introduzca un usuario a quien aceptar.");
        }
    }
}
