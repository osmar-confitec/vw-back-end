using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Calls.Dto;

namespace VolksCalls.Domain.Models.Calls.Response
{
   public class SendFilesToCallsResponse
    {

        public List<SendFilesToCallsDto> SendFiles { get; set; }

        public SendFilesToCallsResponse()
        {
            SendFiles = new List<SendFilesToCallsDto>();
        }

    }
}
