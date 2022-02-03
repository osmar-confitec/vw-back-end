using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Response;
using VolksCalls.Domain.Models.CallsCategory.Response;
using VolksCalls.Domain.Models.CallsPreferences;
using VolksCalls.Domain.Models.CallsPreferences.Response;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Models.CI.Dto;
using VolksCalls.Domain.Models.CI.Response;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.AutoMapper
{
    public class DomainToResponseMappingProfile : Profile
    {


        DateTime DateBr(DateTime dt)
        {
            CultureInfo idioma = new CultureInfo("pt-BR");
            return DateTime.Parse(dt.ToString(), idioma);



        }

        string GetDateBr(DateTime dt)
        {
            return $"{dt.Day}/{dt.Month}/{dt.Year} {dt.Hour}:{dt.Minute}:{dt.Second}"; 
        
        }


        string GetLastDateUpdated(EntityDataBase entityDataBase)
        {
            if (!entityDataBase.Active)
                return GetDateBr(entityDataBase.DeleteDate.Value);

            if (!string.IsNullOrEmpty(entityDataBase.UserAdUpdatedId))
                return GetDateBr(entityDataBase.DateUpdate.Value).ToString();

            return GetDateBr(entityDataBase.DateRegister).ToString();
        }

        string GetLastUserUpdated(EntityDataBase entityDataBase)
        {
            if (!entityDataBase.Active)
                return entityDataBase.UserAdDeletedId;

            if (!string.IsNullOrEmpty(entityDataBase.UserAdUpdatedId))
                return entityDataBase.UserAdUpdatedId;

            return entityDataBase.UserAdInsertedId;
        }
        private string FormatPatchCallsCategory(string Patch)
        => string.Join('/', Patch.Split('|'));
        public DomainToResponseMappingProfile()
        {
            CreateMap<CallCategoryDomain, CallsOpeningPreferencesResponse>();

            CreateMap(typeof(PagedDataResponse<>), typeof(PagedDataResponse<>));


            //

            CreateMap<CallFormDomain, CallFormInsertResponse>();
            CreateMap<CallFormDomain, CallFormUpdateResponse>();



            //

            CreateMap<CallFormQuestionsDomain, CallFormQuestionsInsertResponse>();

            //

            CreateMap<CIDomain, CIGetResponse>()
                     .ForMember(d => d.LastDateUpdated, s => s.MapFrom(m => GetLastDateUpdated(m) ))
                     .ForMember(d => d.LastUserUpdated, s => s.MapFrom(m => GetLastUserUpdated(m)))
                ;

            CreateMap<CallFormDomain, CallFormResponse>()
                 .ForMember(d => d.LastDateUpdated, s => s.MapFrom(m => GetLastDateUpdated(m)))
                 .ForMember(d => d.LastUserUpdated, s => s.MapFrom(m => GetLastUserUpdated(m)))
            ;

            CreateMap<CallsCategoryDomain, CallCategoryInsertResponse>();

            CreateMap<CallsCategoryDomain, CallCategoryUpdateResponse>();
            CreateMap<CallFormQuestionsDomain, CallFormQuestionsUpdateResponse>();

            CreateMap<CIDomain, CIInsertResponse>();
            CreateMap<CIDomain, CIUpdateResponse>();
            CreateMap<CallFormDomain, CallFormDetailsResponse>();

            //


            CreateMap<CIDomain, CIGetDetailsResponse>()
                .ForMember(d => d.CallCategoriesDtos, s => s.MapFrom(m => m.CallsCategories.Select(x=> new CallCategoriesDto { Patch = x.Patch } ) ))
                ;

            //

            CreateMap<CallsCategoryDomain, CallsCategoryGetResponse>()
                .ForMember(d => d.CiCode, s => s.MapFrom(m => m.CI!= null? m.CI.Id.ToString() : "" ))
                .ForMember(d => d.CiName, s => s.MapFrom(m => m.CI != null ? m.CI.CIName : ""))
                .ForMember(d => d.CallForm, s => s.MapFrom(m => m.CallForm != null ? m.CallForm.Name : ""))
                .ForMember(d => d.CallFormId, s => s.MapFrom(m => m.CallForm != null ? m.CallForm.Id.ToString() : ""))
                .ForMember(d => d.CiId, s => s.MapFrom(m => m.CI != null ? m.CI.CIId : ""))
                .ForMember(d => d.CallGroup, s => s.MapFrom(m => m.CI != null ? m.CI.CallGroup : ""))
                .ForMember(d => d.LastDateUpdated, s => s.MapFrom(m => GetLastDateUpdated(m)))
                     .ForMember(d => d.LastUserUpdated, s => s.MapFrom(m => GetLastUserUpdated(m)))
                //              .ForMember(d => d.Patch, s => s.MapFrom(m => FormatPatchCallsCategory(m.Patch)))
                ;

        }
    }
}
