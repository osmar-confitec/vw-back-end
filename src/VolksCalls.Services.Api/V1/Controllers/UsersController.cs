using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Services.Api.Controllers;

namespace VolksCalls.Services.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [Authorize]
    public class UsersController : MainController
    {

        readonly IUsersApplication _usersApplication;
        public UsersController(ILogger<UsersController> logger, IUsersApplication usersApplication, LNotifications notifications)
            : base(logger,notifications)
        {
            _usersApplication = usersApplication;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsersAsync([FromQuery] UsersRequest usersRequest)
          => await ExecControllerAsync(() => _usersApplication.GetUsersAsync(usersRequest));

        [HttpGet("UsersTest")]
        public async Task<IActionResult> GetUsersTestAsync()
            => Ok( await Task.FromResult(true));

        [HttpGet("UsersLogged")]
        public async Task<IActionResult> GetUsersLoggedAsync()
              => await ExecControllerAsync(() => _usersApplication.GetUsersLoggedAsync());

        [HttpGet("UsersIsAuthorized")]
        public async Task<IActionResult> UsersIsAuthorizedAsync([FromQuery] UsersIsAuthorizedRequest usersIsAuthorizedRequest)
              => await ExecControllerAsync(() => _usersApplication.UsersIsAuthorizedAsync( usersIsAuthorizedRequest));

        [HttpPost("UsersUnblock")]
        //[AllowAnonymous]
        public async Task<IActionResult> UsersUnblockAsync([FromBody] UsersUnblockRequest usersUnblockRequest)
            => await ExecControllerAsync(() => _usersApplication.UsersUnblockAsync(usersUnblockRequest));



    }
}
