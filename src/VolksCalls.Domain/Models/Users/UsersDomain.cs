using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Modules;

namespace VolksCalls.Domain.Models.Users
{
   public class UsersDomain
    {

        public string Email { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string Plate { get; set; }

        

        public UsersDomain()
        {
            
        }

    }
}
