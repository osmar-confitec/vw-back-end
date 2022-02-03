using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Domain.Models.Users.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Application.Services
{
    public class UsersApplication : BaseApplication, IUsersApplication
    {

        readonly IUsersService _usersService;
        public UsersApplication(
            IUsersService usersService,
            IUnitOfWork _unitOfWork, LNotifications _LNotifications) : base(_unitOfWork, _LNotifications)
        {
            _usersService = usersService;
        }

        public async Task<IEnumerable<UsersResponse>> GetUsersAsync(UsersRequest usersRequest)
                => await _usersService.GetUsersAsync(usersRequest);
        public async Task<UsersLoggedResponse> GetUsersLoggedAsync()
                => await _usersService.GetUsersLoggedAsync();

        public async Task<bool> UsersIsAuthorizedAsync(UsersIsAuthorizedRequest usersIsAuthorizedRequest)
                 => await _usersService.UsersIsAuthorizedAsync(usersIsAuthorizedRequest);

        public async Task<UsersUnblockResponse> UsersUnblockAsync(UsersUnblockRequest usersUnblockRequest)
         => await _usersService.UsersUnblockAsync(usersUnblockRequest);
    }
}
