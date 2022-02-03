using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallForm.Dto;

namespace VolksCalls.Domain.Models.CallForm.Response
{
  public  class CallFormDetailsResponse
    {

        public string Name { get; set; }
        public CallFormType CallFormType { get; set; }
        public bool IsDefault { get; set; }

        public string Observation { get; set; }

        public Guid Id { get; set; }

        public List<CallFormQuestionsFormsDto> CallFormQuestionsFormsDtos { get; set; }

        public CallFormDetailsResponse()
        {
            CallFormQuestionsFormsDtos = new List<CallFormQuestionsFormsDto>();
        }
    }
}
