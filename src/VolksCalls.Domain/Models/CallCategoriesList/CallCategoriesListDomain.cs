using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallCategoriesList
{
   public class CallCategoriesListDomain : EntityDataBase
    {
        public string DescriptionFirst { get; set; }
        public Guid IdFirst { get; set; }
        public string DescriptionSecond { get; set; }
        public Guid IdSecond { get; set; }
        public string DescriptionThird { get; set; }
        public Guid IdThird { get; set; }
        public string DescriptionFour { get; set; }
        public Guid IdFour { get; set; }
        public Guid? CICode { get; set; }
        public string CIId { get; set; }
        public string CIName { get; set; }
        public string CallGroup { get; set; }

    }
}
