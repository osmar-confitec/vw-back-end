using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallsCategory.Dto
{
  public  class CallsCategoryManageDto
    {

        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid? CICode { get; set; }

        public string CIId { get; set; }

        public string CIName { get; set; }

        public int Position { get; set; }

        public string CallGroup { get; set; }

        public string Patch { get; set; }

        public string CallFormId { get; set; }

        public string CallForm { get; set; }



    }
}
