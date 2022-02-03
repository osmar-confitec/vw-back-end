using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.Calls;
using VolksCalls.Domain.Models.CI;

namespace VolksCalls.Domain.Models
{
   public class CallsCategoryDomain: EntityDataBase
    {
        public string Description { get; set; }
        public Guid? CallsCategoryParentId { get; set; }

        public int QtdChildren { get; set; }
        public virtual CallsCategoryDomain CallsCategoryParent { get; set; }
        public string Patch { get; set; }
        public int Level { get; set; }
        public Guid? CIId { get; set; }

        public Guid? CallFormId { get; set; }
        public virtual CallFormDomain CallForm { get; set; }
        public virtual CIDomain CI { get; set; }
        public virtual List<CallsCategoryDomain> CallsCategoriesChildren { get; set; }

        public virtual IEnumerable<CallsDomain> Calls { get; set; }
        public CallsCategoryDomain()
        {
            CallsCategoriesChildren = new List<CallsCategoryDomain>();
            Calls = new List<CallsDomain>();
        }
    }
}
