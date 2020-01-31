using AutoMapper;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Profiles
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(src =>
                src.PostedBy,
                opt => opt.MapFrom(opt => opt.User.Name + " " + opt.User.Lastname + " " + opt.User.MotherSurname))
                .ForMember(src =>
                src.DatePosted,
                opt => opt.MapFrom(opt => opt.Date));
        }
    }
}
