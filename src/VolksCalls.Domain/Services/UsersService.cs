using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Domain.Models.Users.Response;
using VolksCalls.Infra.CrossCutting;
using System.Linq;
using System.DirectoryServices.AccountManagement;
using Microsoft.AspNetCore.Http;
using VolksCalls.Domain.Models.Modules;
using VolksCalls.Domain.Repository;
using VolksCalls.Domain.Models.Modules.Dto;

namespace VolksCalls.Domain.Services
{
    public class UsersService : BaseService, IUsersService
    {

        public List<UsersResponse> usersResponse;
        readonly IUser _user;
        readonly IUnitOfWork _unitOfWork; 
        readonly IBaseConsultRepository<ModulesDomain> _repositoryConsultModules;

        public UsersService(IUnitOfWork unitOfWork,  LNotifications lNotifications, IUser user)
            : base(lNotifications)
        {

            _unitOfWork = unitOfWork;
            _repositoryConsultModules = _unitOfWork.GetRepository<ModulesDomain>();
            _user = user;


            usersResponse = new List<UsersResponse>() {
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1021"  },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Priscila Alcantara", Plate = "00F110", UserId = "CAD1022" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Patricia Almeida", Plate = "00F110", UserId = "CAD1023" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "José Augusto", Plate = "00F110", UserId = "CAD1024"  },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1025" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1026" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1027"  },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1028" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1029" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1030" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1031" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1032" },
            new UsersResponse { Email = "osmargv99@gmail.com", Name = "Osmar Gonçalves Viera", Plate = "00F110", UserId = "CAD1033"},
            };
        }

        public async Task<IEnumerable<UsersResponse>> GetUsersAsync(UsersRequest usersRequest)
        {
           return await Task.Run(() =>
            {
                var query = usersResponse.AsEnumerable();

                if (!string.IsNullOrEmpty(usersRequest.Name))
                    query = query.Where(x => x.Name.Trim().ToLower().Contains(usersRequest.Name.Trim().ToLower()));

                return query.ToList();
            });
        }

        public async Task<UsersLoggedResponse> GetUsersLoggedAsync()
        {
            var modules =  await _repositoryConsultModules.SearchAsync(x => x.Active);
            var userResponse = new UsersLoggedResponse { Email = "osmargv99@gmail.com", Name = _user?.Name ?? "Osmar Gonçalves Viera", Plate = "00F110", UserId = "TB0IE3Z" };
            foreach (var module in modules)
            {
                userResponse.ModulesPrivates.Add(new Models.Users.Dto.ModulesPrivatesDto { Name = module.Name, 
                    Private = module.ModulesActions.Any(x => x.Active && x.UsersModulesActions.Any(z => z.Active)) });
                userResponse.Modules.Add(new Models.Modules.Dto.ModulesDto
                {
                    Id = module.Id,
                    Name = module.Name,
                    ModulesActionsDto = module.ModulesActions.Where(x=>x.Active).Select(x => 
                        new ModulesActionDto 
                        { 
                            Id = x.Id,
                            ActionName = x.ModulesActionsName,
                            Active = x.UsersModulesActions.Any(z=>z.Active && z.UserId == userResponse.UserId)
                        }).ToList()
                }); ;

            }
            return  userResponse; 
        }

        public  async Task<UsersUnblockResponse> UsersUnblockAsync(UsersUnblockRequest usersUnblockRequest)
        {
            await Task.FromResult(true);
            return new UsersUnblockResponse(); 

        }

        public Task<bool> UsersIsAuthorizedAsync(UsersIsAuthorizedRequest usersIsAuthorizedRequest)
        {
            throw new NotImplementedException();
        }
    }
}
