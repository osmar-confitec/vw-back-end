using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.Calls;
using VolksCalls.Domain.Models.Calls.Request;
using VolksCalls.Domain.Models.Calls.Response;
using VolksCalls.Domain.Models.CallsCategory.Response;

namespace VolksCalls.Domain.Interfaces
{
   public interface ICallsServices:IBaseService<CallsDomain>
    {
        
        Task<CallsOpeningResponse> CallsOpeningAsync(CallsOpeningRequest callsOpeningRequest );

        Task<SendFilesToCallsResponse> SendFilesToCallsAsync(List<IFormFile> files);

        Task OpenMail(CallsOpeningRequest callsOpeningRequest);

        Task<CallsOpeningResponse> CallsOpeningAsync(CallsOpeningRequest callsOpeningRequest, List<IFormFile> files);

    }
}
