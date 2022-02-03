using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallsCategory.Dto
{
   public class CallCategoriesListDto
    {

        public string Description { get; set; }

        public int Level { get; set; }

        public Guid Id { get; set; }


        public string CIId { get; set; }

        public string CIName { get; set; }

        public string CallGroup { get; set; }

    }
}
