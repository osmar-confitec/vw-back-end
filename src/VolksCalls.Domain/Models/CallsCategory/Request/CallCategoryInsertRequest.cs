using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolksCalls.Domain.Models.CallsCategory.Request
{
   public class CallCategoryInsertRequest
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = " Atenção informe uma descrição para a categoria. ")]
        public string Description { get; set; }

        public Guid? CiCode { get; set; }
        public string CallFormId { get; set; }

        public CallCategoryInsertRequest CallCategoryParent { get; set; }

    }
}
