using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Models.CallForm.Request;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Services.Api.Controllers;
using VolksCalls.Services.Api.Filters;

namespace VolksCalls.Services.Api.V1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/callsform")]
    [Authorize]
    public class CallFormController : MainController
    {
        readonly ICallsFormsApplication _callsFormsApplication;

        public CallFormController(ICallsFormsApplication callsFormsApplication, ILogger<MainController> logger, LNotifications notifications) 
            : base(logger, notifications)
        {

            _callsFormsApplication = callsFormsApplication;
        }

               
        [HttpGet("GetCallFormDetails")]
        public async Task<IActionResult> GetCallFormDetailsAsync([FromQuery] Guid Id)
            => await ExecControllerAsync(() => _callsFormsApplication.GetCallFormDetailsAsync(Id));

        [HttpGet("GetCallFormDetailsDefault")]
        
        public async Task<IActionResult> GetCallFormDetailsDefaultAsync()
          => await ExecControllerAsync(() => _callsFormsApplication.GetCallFormDetailsDefaultAsync());


        [HttpPost]
        [AuthorizeFilter(Model = "CallForm", Action = "View")]
        public async Task<IActionResult> CallFormInsertAsync([FromBody] CallFormInsertRequest  callFormInsertRequest)
        {

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(callFormInsertRequest);
            }

            return await ExecControllerAsync(() => _callsFormsApplication.CallFormInsertAsync(callFormInsertRequest));
        }

        [HttpPut]
        [AuthorizeFilter(Model = "CallForm", Action = "View")]
        public async Task<IActionResult> CallFormUpdateAsync([FromBody] CallFormUpdateRequest callFormUpdateRequest )
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(callFormUpdateRequest);
            }
            return await ExecControllerAsync(() => _callsFormsApplication.CallFormUpdateAsync(callFormUpdateRequest));
        }


        [HttpGet("GetCallForm")]
        [AuthorizeFilter(Model = "CallForm", Action = "View")]
        public async Task<IActionResult> GetCallFormAsync([FromQuery] CallFormListRequest cIGetRequest) =>
             await ExecControllerAsync(() => _callsFormsApplication.GetCallFormAsync(cIGetRequest));

        [HttpDelete]
        [AuthorizeFilter(Model = "CallForm", Action = "View")]
        public async Task<IActionResult> DeleteCallFormAsync([FromQuery] Guid id)
        {
            return await ExecControllerAsync(() => _callsFormsApplication.CallFormDeleteAsync(id));
        }

    }
}
