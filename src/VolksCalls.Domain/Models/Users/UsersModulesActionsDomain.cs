using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Modules;

namespace VolksCalls.Domain.Models.Users
{
   public class UsersModulesActionsDomain : EntityDataBase
    {
        public string UserId { get; set; }

        public Guid ModulesActionsId { get; set; }

        public virtual ModulesActionsDomain ModulesActions { get; set; }

        public UsersModulesActionsDomain()
        {

        }
    }
}
