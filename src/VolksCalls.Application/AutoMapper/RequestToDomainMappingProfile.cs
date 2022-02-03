using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Dto;
using VolksCalls.Domain.Models.CallForm.Request;
using VolksCalls.Domain.Models.Calls;
using VolksCalls.Domain.Models.Calls.Request;
using VolksCalls.Domain.Models.CallsCategory.Request;
using VolksCalls.Domain.Models.CallsPreferences;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Models.CI.Request;

namespace VolksCalls.Application.AutoMapper
{
  public  class RequestToDomainMappingProfile : Profile
    {
        public RequestToDomainMappingProfile()
        {
            CreateMap<CallsOpeningRequest, CallCategoryDomain>();
            CreateMap<CIInsertRequest, CIDomain>();
            CreateMap<CallFormInsertRequest, CallFormDomain>()
                
                ;

            CreateMap<CallsOpeningRequest, CallsDomain>()
                .ForMember(d => d.CallFormId, s => s.MapFrom(m => !string.IsNullOrEmpty( m.CallFormId)? new Guid(m.CallFormId) : (Guid?)null ))
                .ForMember(d => d.CallsCategoryId, s => s.MapFrom(m => m.CategoryParentCI))
                ;
            CreateMap<CallFormQuestionsDto, CallFormQuestionsDomain>()
                .ForMember(d => d.DropdownItens, s => s.MapFrom(m => ( m.DropdownQuestionDto != null ) ? JsonConvert.SerializeObject(m.DropdownQuestionDto) : "" ))
               ;

            //

            CreateMap<CallCategoryInsertRequest, CallsCategoryDomain>()
                       .ForMember(d => d.Description, s => s.MapFrom(m => m.Description))
                       .ForMember(d => d.CallFormId, s => s.MapFrom(m => string.IsNullOrEmpty(m.CallFormId) ? (Guid?)null : new Guid(m.CallFormId) ))
                       .ForMember(d => d.CIId, s => s.MapFrom(m => m.CiCode))
                       .ForMember(d => d.CallsCategoryParentId, s => s.MapFrom(m => m.CallCategoryParent == null ? null : (Guid?)m.CallCategoryParent.Id))
                ;
        }
    }
}
