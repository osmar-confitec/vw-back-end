using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Users.Request
{
   public class UsersRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string Plate { get; set; }

        public bool Blocked { get; set; }

    }
}
