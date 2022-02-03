using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallsCategory.Request
{
   public class CallCategoriesChildrenNodesRequest
    {
        public IEnumerable<Guid> AllCallCategoriesCheked { get; set; }
        public Guid CallCategoryChecked { get; set; }

        public IEnumerable<Guid> AllCallCategories { get; set; }


        public CallCategoriesChildrenNodesRequest()
        {
            AllCallCategories = new List<Guid>();
            AllCallCategoriesCheked = new List<Guid>();

        }                                                            
    }
}
