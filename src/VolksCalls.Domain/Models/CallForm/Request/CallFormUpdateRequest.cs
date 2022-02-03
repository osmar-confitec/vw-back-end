using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.CallForm.Dto;

namespace VolksCalls.Domain.Models.CallForm.Request
{
   public class CallFormUpdateRequest : CallFormRequest
    {
        public Guid Id { get; set; }
        public IEnumerable<CallFormQuestionsUpdateDto> CallFormQuestionsFormsDtos { get; set; }

        public CallFormUpdateRequest()
        {
            CallFormQuestionsFormsDtos = new List<CallFormQuestionsUpdateDto>();
        }

    }
}
