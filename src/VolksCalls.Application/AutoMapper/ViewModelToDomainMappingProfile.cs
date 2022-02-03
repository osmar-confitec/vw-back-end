using AutoMapper;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Text;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Domain.Models.Users.Response;
using VolksCalls.Infra.CrossCutting.AD;

namespace VolksCalls.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {


           

          
           
            //
            //    CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
            //        .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            //    CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //        .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
