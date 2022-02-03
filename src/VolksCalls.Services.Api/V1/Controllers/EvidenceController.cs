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
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Emails;
using VolksCalls.Services.Api.Controllers;

namespace VolksCalls.Services.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/evidence")]
    [Authorize]
    public class EvidenceController : MainController
    {
        readonly IEvidenceApplication _evidenceApplication;
        public EvidenceController(ILogger<EvidenceController> logger, LNotifications notifications, IEvidenceApplication evidenceApplication)
            : base(logger,notifications)
        {

            _evidenceApplication = evidenceApplication;
        }

        [HttpGet("SendEMail")]
       // [AllowAnonymous]
        public async Task<IActionResult> SendEMailAsync()
           => await ExecControllerAsync(() => _evidenceApplication.SendEmailAsync());



        [HttpPost("SendEvidences")]
        public async Task<IActionResult> SendEvidencesAsync([FromForm] string sendEvidencesRequests, List<IFormFile> files)
           => await ExecControllerAsync(() => _evidenceApplication.SendEvidencesAsync(sendEvidencesRequests, files));

    }
}
