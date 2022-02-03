using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallsCategory.Dto;

namespace VolksCalls.Domain.Models.CallsCategory.Response
{
   public class CallsCategoryManageResponse
    {

        public List<CallsCategoryManageDto>  callsCategoryManageDtos { get; set; }

        public string Patch { get; set; }

        public CallsCategoryManageResponse()
        {
            callsCategoryManageDtos = new List<CallsCategoryManageDto>();
        }

    }
}
