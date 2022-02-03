using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Response
{
   public class CallFormInsertResponse
    {

        public Guid Id { get; set; }

        public List<CallFormQuestionsInsertResponse>  callFormQuestionsInsertResponses { get; set; }

        public CallFormInsertResponse()
        {
            callFormQuestionsInsertResponses = new List<CallFormQuestionsInsertResponse>();
        }
    }
}
