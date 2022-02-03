using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Modules
{
   public class ModulesDomain : EntityDataBase
    {

        public string Name { get; set; }

        public virtual ICollection<ModulesActionsDomain> ModulesActions { get; set; }


        public ModulesDomain()
        {
            ModulesActions = new List<ModulesActionsDomain>();
        }

    }
}
