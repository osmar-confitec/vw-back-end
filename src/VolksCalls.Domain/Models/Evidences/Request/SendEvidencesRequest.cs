using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Evidences.Request
{
   public class SendEvidencesRequest
    {
        public string RequestNumber { get; set; }

        public string HostName { get; set; }

        public string UserId { get; set; }

        public string InfoAditional { get; set; }
    }
}
