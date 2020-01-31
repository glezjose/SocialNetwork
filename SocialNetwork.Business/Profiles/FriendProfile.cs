using AutoMapper;
using SocialNetwork.DataAccess.DTOs;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Profiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<FriendRelationship, FriendRequestDTO>()
                      .ForMember(src =>
                      src.Name,
                      opt => opt.MapFrom(opt => opt.User.Name + " " + opt.User.Lastname + " " + opt.User.MotherSurname))
                      .ForMember(src =>
                      src.RequestStatus,
                      opt => opt.MapFrom(opt => GetRequestStatus(opt.IsAccepted)));

            CreateMap<FriendRelationship, FriendRequestAddedDTO>()
                      .ForMember(src =>
                      src.Name,
                      opt => opt.MapFrom(opt => opt.FriendUser.Name + " " + opt.FriendUser.Lastname + " " + opt.FriendUser.MotherSurname))
                      .ForMember(src =>
                      src.RequestStatus,
                      opt => opt.MapFrom(opt => GetRequestStatus(opt.IsAccepted)));
        }

        private string GetRequestStatus(bool Status)
        {
            return Status ? "Aceptado" : "Pendiente";
        }
    }
}
