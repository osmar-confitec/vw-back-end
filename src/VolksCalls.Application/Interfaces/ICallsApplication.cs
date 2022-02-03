using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.Calls.Request;
using VolksCalls.Domain.Models.Calls.Response;
using VolksCalls.Domain.Models.CallsPreferences.Request;
using VolksCalls.Domain.Models.CallsPreferences.Response;

namespace VolksCalls.Application.Interfaces
{
    public interface ICallsApplication : IBaseApplication
    {
        Task<CallsOpeningResponse> CallsOpeningAsync(CallsOpeningRequest callsOpeningRequest);

        Task<CallsOpeningPreferencesResponse> CallsOpeningPreferencesAsync(CallsOpeningPreferencesRequest callsOpeningPreferencesRequest);

        Task<SendFilesToCallsResponse> SendFilesToCallsAsync(List<IFormFile> files);

        Task<CallsOpeningResponse> CallsOpeningAsync(string callsOpeningRequest, List<IFormFile> files);


    }
}
