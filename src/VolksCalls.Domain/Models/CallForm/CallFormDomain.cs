using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VolksCalls.Domain.Models.Calls;

namespace VolksCalls.Domain.Models.CallForm
{

    public enum CallFormType
    { 
        [Description("Formulário Simples")]
        SimpleForm = 1
    }
   public class CallFormDomain : EntityDataBase
    {
        public string Name { get; set; }

        public CallFormType CallFormType { get; set; }

        public bool IsDefault { get; set; }

        public string Observation { get; set; }

        public virtual List<CallsCategoryDomain> CallsCategories { get; set; }

        public virtual List<CallFormQuestionsDomain> CallFormsQuestions { get; set; }

        public virtual IEnumerable<CallsDomain> Calls { get; set; }

        public CallFormDomain()
        {
            CallFormsQuestions = new List<CallFormQuestionsDomain>();
            CallFormType = CallFormType.SimpleForm;
            CallsCategories = new List<CallsCategoryDomain>();
            Calls = new List<CallsDomain>();
        }

    }
}
