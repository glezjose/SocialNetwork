using AutoMapper;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.DataAccess.UoW;
using System;
using System.Collections.Generic;

namespace SocialNetwork.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUserRepository<User> _userRepository, IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            userRepository = _userRepository ?? throw new ArgumentNullException(nameof(_userRepository));
            unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public UserDTO GetUser(int UserId)
        {
            return mapper.Map<UserDTO>(userRepository.GetById(UserId));
        }

        public List<UserDTO> GetUsers()
        {
            return userRepository.GetAllUsers().ConvertAll(mapper.Map<UserDTO>);
        }

        public UserDTO AddUser(User user)
        {
            userRepository.Add(user);
            unitOfWork.Commit();

            return mapper.Map<UserDTO>(user);
        }
    }
}
