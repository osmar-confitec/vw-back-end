using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallsCategory.Dto;

namespace VolksCalls.Domain.Models.CallsCategory.Response
{
    public  class CallCategoriesResponse
    {
        public CallCategoryDto Root { get; set; }

        public List<CallCategoryDto> CallCategoriesDtos { get; set; }

        public CallCategoriesResponse()
        {
            CallCategoriesDtos = new List<CallCategoryDto>();
        }
    }
}
