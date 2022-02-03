using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Models.CI.Request
{
   public class CIGetRequest : PagedDataRequest
    {
        public string CIName { get; set; }

        public string CIId { get; set; }

        public bool Active { get; set; }


    }
}
