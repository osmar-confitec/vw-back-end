using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Response
{
   public class CallFormResponse
    {

        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }

        public string LastUserUpdated { get; set; }

        public string LastDateUpdated { get; set; }
    }
}
