using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VolksCalls.Domain.Models.CallForm.Dto;

namespace VolksCalls.Domain.Models.CallForm.Request
{
   public class CallFormInsertRequest: CallFormRequest
    {
        public IEnumerable<CallFormQuestionsDto> CallFormQuestions { get; set; }

        public CallFormInsertRequest()
        {
            CallFormQuestions = new List<CallFormQuestionsDto>();
        }

    }
}
