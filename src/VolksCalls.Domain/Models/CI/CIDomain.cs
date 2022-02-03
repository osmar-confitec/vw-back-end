using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CI
{
   public class CIDomain: EntityDataBase
    {
        public string CIName { get; set; }

        public string CIId { get; set; }

        public bool DefaultCI { get; set; }

        public string CallGroup { get; set; }

        public virtual List<CallsCategoryDomain> CallsCategories { get; set; }

        public CIDomain()
        {
            CallsCategories = new List<CallsCategoryDomain>();
        }
    }
}
