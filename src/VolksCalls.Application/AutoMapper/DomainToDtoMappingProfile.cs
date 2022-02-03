using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Dto;
using VolksCalls.Domain.Models.CallsCategory.Dto;

namespace VolksCalls.Application.AutoMapper
{
   public class DomainToDtoMappingProfile : Profile
    {

        public DomainToDtoMappingProfile()
        {

            CreateMap<CallFormQuestionsDomain, CallFormQuestionsFormsDto>()
                .ForMember(d => d.DropdownQuestionDto, s => s.MapFrom(m => string.IsNullOrEmpty(m.DropdownItens)? new DropdownQuestionDto() : JsonConvert.DeserializeObject<DropdownQuestionDto>(m.DropdownItens)))
                ;
            //JsonConvert
            CreateMap<CallsCategoryDomain, CallCategoryDto>()
                    .ForMember(d => d.Text, s => s.MapFrom(m => m.Description))
                    .ForMember(d => d.QtdChildren, s => s.MapFrom(m => m.QtdChildren))
                    .ForMember(d => d.ParentId, s => s.MapFrom(m => m.CallsCategoryParentId.ToString()))
                    .ForMember(d => d.IsCI, s => s.MapFrom(m => m.CIId.HasValue ))
                    .ForMember(d => d.Level, s => s.MapFrom(m => m.Level))
                    .ForMember(d => d.IsContainsForm, s => s.MapFrom(m => m.CallFormId.HasValue && m.CallForm.Active))
                    .ForMember(d => d.FormId, s => s.MapFrom(m => m.CallFormId))
                    .ForMember(d => d.Value, s => s.MapFrom(m => m.Id.ToString()))
                ;


            CreateMap<CallsCategoryDomain, CallsCategoryManageDto>()
                .ForMember(d => d.CICode, s => s.MapFrom(m => m.CIId))
                .ForMember(d => d.CIId, s => s.MapFrom(m => m.CI == null ? string.Empty : m.CI.CIId))
                .ForMember(d => d.CIName, s => s.MapFrom(m => m.CI == null ? string.Empty : m.CI.CIName))
                .ForMember(d => d.CallForm, s => s.MapFrom(m => m.CallForm == null ? string.Empty : m.CallForm.Name))
                .ForMember(d => d.CallFormId, s => s.MapFrom(m => m.CallForm == null ? string.Empty : m.CallForm.Id.ToString()))
                .ForMember(d => d.CallGroup, s => s.MapFrom(m => m.CI == null ? string.Empty : m.CI.CallGroup))
                ;

            /**/
        }

    }
}
