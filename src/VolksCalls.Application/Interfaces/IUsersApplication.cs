using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Domain.Models.Users.Response;

namespace VolksCalls.Application.Interfaces
{
   public interface IUsersApplication : IBaseApplication
    {
        Task<UsersLoggedResponse> GetUsersLoggedAsync();

        Task<IEnumerable<UsersResponse>> GetUsersAsync(UsersRequest usersRequest);

        Task<bool> UsersIsAuthorizedAsync(UsersIsAuthorizedRequest usersIsAuthorizedRequest);

        Task<UsersUnblockResponse> UsersUnblockAsync(UsersUnblockRequest usersUnblockRequest);

    }
}
