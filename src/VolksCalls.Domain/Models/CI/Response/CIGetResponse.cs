using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CI.Response
{
   public class CIGetResponse
    {

        public string CIName { get; set; }

        public string CIId { get; set; }

        public string CallGroup { get; set; }

        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string LastUserUpdated { get; set; }

        public string LastDateUpdated { get; set; }

    }
}
