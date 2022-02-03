using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Domain.Models.Users.Response;

namespace VolksCalls.Domain.Interfaces
{
   public interface IUsersService
    {

        Task<UsersLoggedResponse> GetUsersLoggedAsync();

        Task<UsersUnblockResponse> UsersUnblockAsync(UsersUnblockRequest usersUnblockRequest);

        Task<IEnumerable<UsersResponse>> GetUsersAsync(UsersRequest usersRequest);

        Task<bool> UsersIsAuthorizedAsync(UsersIsAuthorizedRequest usersIsAuthorizedRequest);
    }
}
