using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.Calls.Dto
{
   public class SendFilesToCallsDto
    {

        public Guid Id { get; set; }

        public string FileName { get; set; }

        public SendFilesToCallsDto()
        {
            Id = Guid.NewGuid();
        }

    }
}
