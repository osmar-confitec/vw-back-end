using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolksCalls.Domain.Models.CallForm.Dto
{
   public class DropdownQuestionDto
    {

       
        public string Key { get; set; }

        public string Label { get; set; }

        
        public IEnumerable<DropdownQuestionOptionsDto> DropDownQuestionOptionsDtos { get; set; }

        public DropdownQuestionDto()
        {
            DropDownQuestionOptionsDtos = new List<DropdownQuestionOptionsDto>();
        }
        
    }
}
