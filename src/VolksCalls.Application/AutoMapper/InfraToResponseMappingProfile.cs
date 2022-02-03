using AutoMapper;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Text;
using VolksCalls.Domain.Models.Users.Response;

namespace VolksCalls.Application.AutoMapper
{
   public class InfraToResponseMappingProfile : Profile
    {

        public InfraToResponseMappingProfile()
        {
            CreateMap<Principal, UsersResponse>()
              .ForMember(d => d.Email, s => s.MapFrom(m => m.UserPrincipalName))
              .ForMember(d => d.Name, s => s.MapFrom(m => m.DisplayName))
              .ForMember(d => d.UserId, s => s.MapFrom(m => m.SamAccountName))
              .ForMember(d => d.Plate, s => s.MapFrom(m => m.Description))
              ;

            CreateMap<UserPrincipal, UsersLoggedResponse>()
               .ForMember(d => d.Email, s => s.MapFrom(m => m.UserPrincipalName))
               .ForMember(d => d.Name, s => s.MapFrom(m => m.DisplayName))
               .ForMember(d => d.UserId, s => s.MapFrom(m => m.SamAccountName))
               .ForMember(d => d.Plate, s => s.MapFrom(m => m.Description))
               ;

        }

    }
}
