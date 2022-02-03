using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Calls.Request;
using VolksCalls.Domain.Models.CallsPreferences.Request;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Emails;
using VolksCalls.Services.Api.Controllers;

namespace VolksCalls.Services.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/calls")]
    [Authorize]
    public class CallsController : MainController
    {

        
        readonly ICallsApplication _callsApplication;
        public CallsController(ILogger<CallsController> logger,ICallsApplication callsApplication, LNotifications notifications) : base(logger,notifications)
        {
            _callsApplication = callsApplication;
        }

        [HttpGet("CallOpeningPreferences")]
        public async Task<IActionResult> GetCallOpeningPreferencesAsync([FromQuery] CallsOpeningPreferencesRequest callsOpeningPreferencesRequest)
                => await ExecControllerAsync(() => _callsApplication.CallsOpeningPreferencesAsync(callsOpeningPreferencesRequest));

        [HttpPost("CallsOpening")]
        public async Task<IActionResult> CallsOpeningAsync([FromBody] CallsOpeningRequest callOpeningRequest) 
            => await ExecControllerAsync(()=> _callsApplication.CallsOpeningAsync(callOpeningRequest));

        [HttpPost("CallsOpeningSendFiles")]
        public async Task<IActionResult> CallsOpeningSendFilesAsync([FromForm]string callOpeningRequest, List<IFormFile> files)
            => await ExecControllerAsync(() => _callsApplication.CallsOpeningAsync( callOpeningRequest,files));

        [HttpPost("SendFilesToCalls")]
        public async Task<IActionResult> SendFilesToCallsAsync([FromForm]List<IFormFile> files)
            => await ExecControllerAsync(() => _callsApplication.SendFilesToCallsAsync(files));
    }
}
