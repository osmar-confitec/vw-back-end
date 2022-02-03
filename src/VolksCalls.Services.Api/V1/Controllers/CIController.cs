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
using VolksCalls.Domain.Models.CI.Request;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Emails;
using VolksCalls.Services.Api.Controllers;
using VolksCalls.Services.Api.Filters;

namespace VolksCalls.Services.Api.V1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/ci")]
    [Authorize]
    public class CIController : MainController
    {

        readonly ICIApplication _cIApplication;
        public CIController(ILogger<CIController> logger,
            ICIApplication cIApplication,
            LNotifications notifications)
            : base(logger, notifications)
        {

            _cIApplication = cIApplication;
        }


        [HttpGet("GetCIChoice")]
        [AuthorizeFilter(Model = "CallingCategories", Action = "View")]
        public async Task<IActionResult> GetCIChoiceAsync([FromQuery] CIGetRequest cIGetRequest) =>
                     await ExecControllerAsync(() => _cIApplication.GetCIChoiceAsync(cIGetRequest));



        [HttpGet("GetCI")]
        [AuthorizeFilter(Model = "CI", Action = "View")]
        public async Task<IActionResult> GetCIAsync([FromQuery] CIGetRequest cIGetRequest) =>
                    await ExecControllerAsync(() => _cIApplication.GetCIChoiceAsync(cIGetRequest));


        [HttpGet("GetCIDetails")]
        [AuthorizeFilter(Model = "CI", Action = "View")]
        public async Task<IActionResult> GetCIDetailsAsync([FromQuery] Guid Id) 
            =>  await ExecControllerAsync(() => _cIApplication.CIGetDetailsAsync(Id));



        [HttpPost]
        [AuthorizeFilter(Model = "CI", Action = "View")]
        public async Task<IActionResult> InsertCIAsync([FromBody] CIInsertRequest cIInsertRequest)
        {

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(cIInsertRequest);
            }

            return await ExecControllerAsync(() => _cIApplication.CIInsertAsync(cIInsertRequest));
        }

        [HttpPut]
        [AuthorizeFilter(Model = "CI", Action = "View")]
        public async Task<IActionResult> UpdateCIAsync([FromBody] CIUpdateRequest cIUpdateRequest )
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(cIUpdateRequest);
            }
            return await ExecControllerAsync(() => _cIApplication.CIUpdateAsync(cIUpdateRequest));
        }

        [HttpDelete]
        [AuthorizeFilter(Model = "CI", Action = "View")]
        public async Task<IActionResult> DeleteCIAsync([FromQuery] Guid id)
        {

            return await ExecControllerAsync(() => _cIApplication.CIDeleteAsync(id));
        }


    }
}
