using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Modules.Dto
{
    public class ModulesActionDto
    {


        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string ActionName { get; set; }


    }
}
