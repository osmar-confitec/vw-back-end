using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Users;

namespace VolksCalls.Domain.Models.Modules
{
   public class ModulesActionsDomain : EntityDataBase
    {
        public string ModulesActionsName { get; set; }
        public Guid ModulesId { get; set; }
        public virtual ModulesDomain Modules { get; set; }

        public virtual IEnumerable<UsersModulesActionsDomain> 
            UsersModulesActions  { get; set; }

        public ModulesActionsDomain()
        {
            UsersModulesActions = new List<UsersModulesActionsDomain>();
        }
    }
}
