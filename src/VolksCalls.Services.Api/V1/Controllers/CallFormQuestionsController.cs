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
    [Route("api/v{version:apiVersion}/callsformquestion")]
    [Authorize]
    public class CallFormQuestionsController : MainController
    {
        readonly ICallFormQuestionsApplication  _callFormQuestionsApplication;
        public CallFormQuestionsController(ICallFormQuestionsApplication callFormQuestionsApplication, ILogger<MainController> logger, LNotifications notifications) : base(logger, notifications)
        {
            _callFormQuestionsApplication = callFormQuestionsApplication;
        }

        [HttpDelete]
        [AuthorizeFilter(Model = "CallForm", Action = "View")]
        public async Task<IActionResult> DeleteCallFormAsync([FromQuery] Guid id)
        {
            return await ExecControllerAsync(() => _callFormQuestionsApplication.CallFormQuestionsDeleteAsync(id));
        }

    }
}
