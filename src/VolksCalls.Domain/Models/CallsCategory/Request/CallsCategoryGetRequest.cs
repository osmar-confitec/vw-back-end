using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Models.CallsCategory.Request
{
   public class CallsCategoryGetRequest : PagedDataRequest
    {

        public string Description { get; set; }

        public string Path { get; set; }

        public bool? Active { get; set; }

        public bool SearchExactWord { get; set; }

    }
}
