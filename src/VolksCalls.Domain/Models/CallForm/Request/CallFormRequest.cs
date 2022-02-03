using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Request
{
   public abstract class CallFormRequest
    {

        [Required(ErrorMessage = " Atenção Preencha o nome do formulário. ")]
        [StringLength(200, ErrorMessage = "O {0} campo tem que estar {2} e {1} characters", MinimumLength = 6)]
        public string Name { get; set; }

        [Required(ErrorMessage = " Atenção Preencha o tipo de formulário. ")]
        public CallFormType CallFormType { get; set; }
        public bool IsDefault { get; set; }
        public string Observation { get; set; }
    }
}
