using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Models.CallForm.Request
{
   public class CallFormListRequest : PagedDataRequest
    {
        public string Name { get; set; }

        public bool Active { get; set; }

    }
}
