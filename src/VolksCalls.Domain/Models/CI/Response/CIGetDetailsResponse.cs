using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CI.Dto;

namespace VolksCalls.Domain.Models.CI.Response
{
   public class CIGetDetailsResponse
    {

        public string CIName { get; set; }

        public string CIId { get; set; }

        public bool DefaultCI { get; set; }

        public string CallGroup { get; set; }

        public List<CallCategoriesDto> CallCategoriesDtos  { get; set; }

        public CIGetDetailsResponse()
        {
            CallCategoriesDtos = new List<CallCategoriesDto>();
        }

    }
}
