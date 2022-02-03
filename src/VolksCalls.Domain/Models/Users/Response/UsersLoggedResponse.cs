using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Modules.Dto;
using VolksCalls.Domain.Models.Users.Dto;

namespace VolksCalls.Domain.Models.Users.Response
{
   public class UsersLoggedResponse
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string Plate { get; set; }

        public List<ModulesPrivatesDto> ModulesPrivates { get; set; }

        public List<ModulesDto> Modules { get; set; }

        public UsersLoggedResponse()
        {
            ModulesPrivates = new List<ModulesPrivatesDto>();
            Modules = new List<ModulesDto>();
        }
    }
}
