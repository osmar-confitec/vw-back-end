using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.AD
{
   public class ActiveDirectoryInfraSettings
    {

        public string Domain { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ContextType { get; set; }


    }
}
