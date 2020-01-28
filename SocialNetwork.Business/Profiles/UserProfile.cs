using AutoMapper;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(src => 
                    src.Name,
                    opt => opt.MapFrom(src => src.Name + " " + src.Lastname + " " + src.MotherSurname));
        }
    }
}
