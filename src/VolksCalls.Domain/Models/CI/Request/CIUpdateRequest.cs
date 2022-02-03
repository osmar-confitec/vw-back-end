using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolksCalls.Domain.Models.CI.Request
{
  public class CIUpdateRequest
    {

        [Required(ErrorMessage ="Atenção digite o Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Atenção digite o CIId")]
        public string CIId { get; set; }

        [Required(ErrorMessage = "Atenção digite o CIName")]
        public string CIName { get; set; }

        [Required(ErrorMessage = "Atenção digite o CallGroup")]
        public string CallGroup { get; set; }

        [Required(ErrorMessage = "Atenção digite o DefaultCI")]
        public bool DefaultCI { get; set; }

    }
}
