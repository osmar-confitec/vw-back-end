using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Infra.CrossCutting.AD;

namespace VolksCalls.Application.AutoMapper
{
  public  class RequestToInfraMappingProfile:Profile
    {

        public RequestToInfraMappingProfile()
        {

            CreateMap<UsersRequest, ActiveDirectoryQuery>()
                 .ForMember(d => d.DisplayName, s => s.MapFrom(m => m.Name))
                 .ForMember(d => d.SamAccountName, s => s.MapFrom(m => m.UserId))
                 ;

        }

       
    }
}
