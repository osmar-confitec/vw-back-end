using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.AD
{
   public class ActiveDirectoryInfra: IActiveDirectoryInfra
    {

        /*
         using (var context = new PrincipalContext(ContextType.Domain))
using (var user = new UserPrincipal(context)
{
    UserPrincipalName = "username",
    Enabled = true
})
{
    user.SetPassword("password");
    user.Save();
}
         
         */

        readonly ActiveDirectoryInfraSettings  _activeDirectoryInfraSettings;

        PrincipalContext _principalContext;
        UserPrincipal _principal;

        public ActiveDirectoryInfra(IOptions<ActiveDirectoryInfraSettings> activeDirectoryInfraSettings)
        {
            _activeDirectoryInfraSettings = activeDirectoryInfraSettings.Value;

            _principalContext = new PrincipalContext(_activeDirectoryInfraSettings.ContextType.GetEnumToName<ContextType>(ContextType.ApplicationDirectory),
                                                     _activeDirectoryInfraSettings.Domain == ""  ?  null: _activeDirectoryInfraSettings.Domain,
                                                     _activeDirectoryInfraSettings.UserName,
                                                     _activeDirectoryInfraSettings.Password);



        }

        void ReadPrincipal()
        {
            _principal = new UserPrincipal(_principalContext);
        }

        public List<Principal> FindDomainUser(ActiveDirectoryQuery activeDirectoryQuery)
        {

            ReadPrincipal();

            if (!string.IsNullOrEmpty(activeDirectoryQuery.SamAccountName))
                _principal.SamAccountName = $"*{activeDirectoryQuery.SamAccountName}*";

            if (!string.IsNullOrEmpty(activeDirectoryQuery.DisplayName))
                _principal.DisplayName = $"*{activeDirectoryQuery.DisplayName}*";

            if (string.IsNullOrEmpty(activeDirectoryQuery.DisplayName) && string.IsNullOrEmpty(activeDirectoryQuery.SamAccountName))
                _principal.UserPrincipalName = "*@*";


            PrincipalSearcher searcher = new PrincipalSearcher(_principal);
            var users = searcher.FindAll().AsQueryable().ToList();
            return users;
        }


        public UserPrincipal GetAdUser(IdentityType identityType, string samAccountName)
        {
            ReadPrincipal();
            return UserPrincipal.FindByIdentity(_principalContext, identityType, samAccountName);
        }
        public void UnlockUserAD(UserPrincipal userPrincipal)
        {
            if (userPrincipal.IsAccountLockedOut())
                userPrincipal.UnlockAccount();
        }
    }
}
