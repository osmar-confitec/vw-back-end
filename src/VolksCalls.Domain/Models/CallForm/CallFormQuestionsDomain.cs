using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm
{

    public enum QuestionType
    {
        [Description("text")]
        TextBox = 1,
        [Description("textarea")]
        TextArea = 2,
        [Description("dropDown")]
        DropDown = 3
    }

    public enum CallFormQuestionType
    { 
        [Description("Simples Questão")]
        SimpleQuestion = 1
    
    }
    public class CallFormQuestionsDomain : EntityDataBase
    {

        public QuestionType QuestionType { get; set; }

        public CallFormQuestionType CallFormQuestionType { get; set; }

        public string Key { get; set; }

        public string Label { get; set; }

        public bool Required { get; set; }

        public string DropdownItens { get; set; }

        public int Order { get; set; }

        public Guid CallFormId { get; set; }

        public virtual CallFormDomain CallForm { get; set; }

        public CallFormQuestionsDomain()
        {
            CallFormQuestionType = CallFormQuestionType.SimpleQuestion;
            QuestionType = QuestionType.TextBox;
        }
    }
}
