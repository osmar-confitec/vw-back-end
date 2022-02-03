using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolksCalls.Services.Api.Models
{
    public class ErrorLog
    {

        public string Message { get; set; }

        public string InnerException { get; set; }

        public string StackTrace { get; set; }

    }
}
