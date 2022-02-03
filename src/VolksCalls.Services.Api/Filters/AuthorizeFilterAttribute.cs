using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Models.Users;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Services.Api.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {

        public string Model { get; set; }

        public string Action { get; set; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _unitOfWork = (IUnitOfWork)context.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));
            var _users  = (IUsersApplication)context.HttpContext.RequestServices.GetService(typeof(IUsersApplication));
            var _usersLogged = await _users.GetUsersLoggedAsync();


            var repoConsultUsersModulesActions = _unitOfWork.GetRepository<UsersModulesActionsDomain>();

            if (await repoConsultUsersModulesActions.ExistsAsync(x => x.Active &&
                                                        x.ModulesActions.Active &&
                                                        x.ModulesActions.ModulesActionsName == Action &&
                                                        x.ModulesActions.Modules.Name == Model &&
                                                        x.ModulesActions.Modules.Active &&
                                                        x.UserId == _usersLogged.UserId
                                                        ))
            {
                await base.OnActionExecutionAsync(context, next);
                return;
            }
            await NoAuth(context, next);
            return;
        }

        async Task NoAuth(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.Result = new ContentResult() { StatusCode = 401 };
            await base.OnActionExecutionAsync(context, next);

        }

    }
    }
