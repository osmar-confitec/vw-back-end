using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Users.Request
{
  public class UsersIsAuthorizedRequest
    {

        public string UserId { get; set; }

        public string Module { get; set; }

        public string ModuleAction { get; set; }



    }
}
