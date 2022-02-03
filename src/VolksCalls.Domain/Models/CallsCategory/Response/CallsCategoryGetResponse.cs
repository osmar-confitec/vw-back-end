using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallsCategory.Response
{
   public class CallsCategoryGetResponse
    {

        public string Patch { get; set; }

        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string CiId { get; set; }

        public string CallFormId { get; set; }

        public string CallForm { get; set; }
        public string CiCode { get; set; }

        public string CiName { get; set; }

        public string CallGroup { get; set; }

        public string LastUserUpdated { get; set; }

        public string LastDateUpdated { get; set; }


    }
}
