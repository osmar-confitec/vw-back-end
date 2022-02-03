using AutoMapper;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Modules;
using VolksCalls.Domain.Models.Modules.Dto;
using VolksCalls.Domain.Models.Users.Request;
using VolksCalls.Domain.Models.Users.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.AD;

namespace VolksCalls.Domain.Services
{
    public class UsersADService : BaseService, IUsersService
    {

        readonly IActiveDirectoryInfra _activeDirectoryInfra;
        readonly IUser _user;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly IBaseConsultRepository<ModulesDomain> _repositoryConsultModules;
        public UsersADService(IUnitOfWork unitOfWork,IMapper mapper, IUser user, IActiveDirectoryInfra activeDirectoryInfra, LNotifications lNotifications)
            : base(lNotifications)
        {
            _user = user;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _activeDirectoryInfra = activeDirectoryInfra;
            _repositoryConsultModules = _unitOfWork.GetRepository<ModulesDomain>();
        }

        public async Task<IEnumerable<UsersResponse>> GetUsersAsync(UsersRequest usersRequest)
        {
            var listPrincipal = new List<Principal>();
            var listUserResponse = new List<UsersResponse>();
            

            await Task.Run(() =>
            {
                listPrincipal.AddRange(_activeDirectoryInfra.FindDomainUser(_mapper.Map<ActiveDirectoryQuery>(usersRequest)));

                ;
            });

            foreach (var principalItem in listPrincipal)
            {
                string propAdPlate = GetPlate(principalItem);

                listUserResponse.Add(new UsersResponse
                {

                    Email = principalItem.UserPrincipalName,
                    Name = principalItem.DisplayName,
                    UserId = principalItem.SamAccountName,
                    Plate = propAdPlate ?? principalItem.Description

                });
            }

            return listUserResponse;
        }

         string GetPlate(Principal principalItem)
        {
            var propAd = principalItem.GetUnderlyingObject() as System.DirectoryServices.DirectoryEntry;
            string propAdPlate = null;
            try
            {

                propAdPlate = propAd.Properties["extensionAttribute1"].Value.ToString();
            }
            catch (Exception ex)
            {


            }

            return propAdPlate;
        }

        public async Task<UsersLoggedResponse> GetUsersLoggedAsync()
        {
            var userPrincipal = default(UserPrincipal);
            var modules = await _repositoryConsultModules.SearchAsync(x => x.Active);
            userPrincipal = _activeDirectoryInfra.GetAdUser(IdentityType.SamAccountName, _user.Name);
            
            
            string propAdPlate = GetPlate(userPrincipal);
            var userResponse = new UsersLoggedResponse
            {

                Email = userPrincipal.UserPrincipalName,
                Name = userPrincipal.DisplayName,
                UserId = userPrincipal.SamAccountName,
                Plate = propAdPlate ?? userPrincipal.Description

            };
            foreach (var module in modules)
            {
                userResponse.ModulesPrivates.Add(new Models.Users.Dto.ModulesPrivatesDto
                {
                    Name = module.Name,
                    Private = module.ModulesActions.Any(x => x.Active && x.UsersModulesActions.Any(z => z.Active))
                });
                userResponse.Modules.Add(new Models.Modules.Dto.ModulesDto
                {

                    Id = module.Id,
                    Name = module.Name,
                    ModulesActionsDto = module.ModulesActions.Where(x => x.Active).Select(x =>
                          new ModulesActionDto
                          {
                              Id = x.Id,
                              ActionName = x.ModulesActionsName,
                              Active = x.UsersModulesActions.Any(z => z.Active && z.UserId == userResponse.UserId)
                          }).ToList()
                }); ;
            }
            return userResponse;
        }
        public async Task<UsersUnblockResponse> UsersUnblockAsync(UsersUnblockRequest usersUnblockRequest)
        {
            await Task.Run(() => {

                //var userUnlock = _activeDirectoryInfra.GetAdUser(IdentityType.SamAccountName, usersUnblockRequest.UserId);
                //_activeDirectoryInfra.UnlockUserAD(userUnlock);
            });
            return new UsersUnblockResponse();
        }

        public Task<bool> UsersIsAuthorizedAsync(UsersIsAuthorizedRequest usersIsAuthorizedRequest)
        {
            throw new NotImplementedException();
        }
    }
}
