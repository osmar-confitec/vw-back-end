using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Calls.Request;
using VolksCalls.Domain.Models.Calls.Response;
using VolksCalls.Domain.Models.CallsPreferences;
using VolksCalls.Domain.Models.CallsPreferences.Request;
using VolksCalls.Domain.Models.CallsPreferences.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Emails;

namespace VolksCalls.Application.Services
{
    public class CallsApplication : BaseApplication, ICallsApplication
    {
        readonly ICallsServices _callsService;
        readonly IBaseConsultRepository<CallCategoryDomain> _callsPreferencesDomain;
        readonly IMapper _mapper;
        public CallsApplication(IUnitOfWork unitOfWork,
                                  ICallsServices callsService,
                                  IMapper mapper,
                                  LNotifications lNotifications)
           : base(unitOfWork, lNotifications)
        {

            _callsService = callsService;
            _mapper = mapper;
            _callsPreferencesDomain = unitOfWork.GetRepository<CallCategoryDomain>();
        }

        public async Task<CallsOpeningResponse> CallsOpeningAsync(CallsOpeningRequest callsOpeningRequest)
        {
            return await _callsService.CallsOpeningAsync(callsOpeningRequest);

        }

        public async Task<CallsOpeningResponse> CallsOpeningAsync(string callsOpeningRequest, List<IFormFile> files)
        {

            var request = JsonConvert.DeserializeObject<CallsOpeningRequest>(callsOpeningRequest);
            ValidAnnotation(request);
            if (LNotifications.Any())
                return null;


            var callResponse = await _callsService.CallsOpeningAsync(request, files);
            await unitOfWork.CommitAsync();
            return callResponse;
        }

        public async Task<CallsOpeningPreferencesResponse> CallsOpeningPreferencesAsync(CallsOpeningPreferencesRequest callsOpeningPreferencesRequest)
        {
            var callPreferences = (await _callsPreferencesDomain.SearchAsync(x => x.Active && x.UserId == callsOpeningPreferencesRequest.UserId)).FirstOrDefault();
            if (callPreferences == null)
                return new CallsOpeningPreferencesResponse { FindPreferences = false };

            var returnCallPreferences = _mapper.Map<CallsOpeningPreferencesResponse>(callPreferences);
            returnCallPreferences.FindPreferences = true;
            return returnCallPreferences;
        }

        public async Task<SendFilesToCallsResponse> SendFilesToCallsAsync(List<IFormFile> files)
        {
            return await _callsService.SendFilesToCallsAsync(files);
        }
    }
}
