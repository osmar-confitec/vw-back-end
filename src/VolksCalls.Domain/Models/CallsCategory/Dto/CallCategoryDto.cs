using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallsCategory.Dto
{
   public class CallCategoryDto
    {

        public string Text { get; set; }

        public string Value { get; set; }

        public bool Checked { get; set; }

        public string ParentId { get; set; }

        public string Path { get; set; }

        public int QtdChildren { get; set; }

        public bool IsCI { get; set; }

        public bool IsParentCI { get; set; }

        public bool? Disabled { get; set; }

        public bool IsContainsForm { get; set; }

        public Guid? FormId { get; set; }



        public List<CallCategoryDto> Children { get; set; }

        public int Level { get; set; }

        public CallCategoryDto()
        {
           
            Children = new List<CallCategoryDto>();
        }

    }
}
