using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Dto
{
   public class CallFormQuestionsFormsDto
    {

        public Guid Id { get; set; }
        public QuestionType QuestionType { get; set; }

        
        public CallFormQuestionType CallFormQuestionType { get; set; }

        public DropdownQuestionDto DropdownQuestionDto { get; set; }


        
        public string Key { get; set; }

        
        public string Label { get; set; }

        public bool Required { get; set; }

        public int Order { get; set; }


    }
}
