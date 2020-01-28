using FluentValidation;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;

namespace SocialNetwork.DataAccess.Validations
{
    public class UserValidator: AbstractValidator<User>
    {
        private readonly IUserRepository<User> userRepository;

        public UserValidator(IUserRepository<User> _userRepository)
        {
            userRepository = _userRepository ?? throw new System.ArgumentNullException(nameof(_userRepository));

            RuleFor(u => u.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.");
            RuleFor(u => u.Lastname).NotEmpty().WithMessage("El apellido paterno no puede estar vacío.");
            RuleFor(u => u.MotherSurname).NotEmpty().WithMessage("El apellido materno no puede estar vacío.");

            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("El número telefónico no puede estar vacío.")
                                       .MinimumLength(10).WithMessage("El número telefónico debe ser mínimo 10 dígitos.")
                                       .MaximumLength(10).WithMessage("El número telefónico debe ser máximo 10 dígitos.")
                                       .Must(userRepository.PhoneNumberNotExists).WithMessage("Ya existe un usuario registrado con ese número telefónico.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("El correo electrónico no puede estar vacío")
                                 .EmailAddress().WithMessage("El correo electrónico no tiene el formato correcto")
                                 .Must(userRepository.EmailNotExists).WithMessage("Ya existe un usuario registrado con ese correo electrónico.");
        }
    }
}
