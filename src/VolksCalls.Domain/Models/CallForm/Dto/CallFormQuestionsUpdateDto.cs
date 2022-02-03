using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Dto
{

    public enum StateFormQuestions
    { 
        
        Insert, 
        Update
    
    }
  public  class CallFormQuestionsUpdateDto: CallFormQuestionsDto
    {

        public string Id { get; set; }

        public StateFormQuestions StateFormQuestions { get; set; }

        public CallFormQuestionsUpdateDto()
        {
            StateFormQuestions = StateFormQuestions.Insert;
        }

    }
}
