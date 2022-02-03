using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Modules.Dto
{
   public class ModulesDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ModulesActionDto> ModulesActionsDto { get; set; }

        public ModulesDto()
        {
            ModulesActionsDto = new List<ModulesActionDto>();
        }


    }
}
