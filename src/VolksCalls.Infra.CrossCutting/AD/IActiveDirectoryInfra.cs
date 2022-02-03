using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.AD
{
   public interface IActiveDirectoryInfra
    {

        UserPrincipal GetAdUser(IdentityType identityType ,string samAccountName);
        List<Principal> FindDomainUser(ActiveDirectoryQuery activeDirectoryQuery );

        void UnlockUserAD(UserPrincipal userPrincipal);

    }
}
