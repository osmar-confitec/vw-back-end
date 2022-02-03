using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Dto
{
    public class CallFormQuestionsDto
    {
        [Required(ErrorMessage = " Atenção informe o tipo de questão. ")]
        public QuestionType QuestionType { get; set; }

        [Required(ErrorMessage = " Atenção Preencha o tipo de formulário. ")]
        public CallFormQuestionType CallFormQuestionType { get; set; }

        public DropdownQuestionDto DropdownQuestionDto { get; set; }


        [Required(ErrorMessage = " Atenção Preencha a key da questão. ")]
        [StringLength(50, ErrorMessage = "O {0} campo tem que estar {2} e {1} characters", MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage =
            "Para o campo de chave deve conter apenas números e letras sem acentuação e espaços em branco.")]
        public string Key { get; set; }

        [Required(ErrorMessage = " Atenção Preencha o Label da questão. ")]
        public string Label { get; set; }

        public bool Required { get; set; }

        public int Order { get; set; }


    }
}
