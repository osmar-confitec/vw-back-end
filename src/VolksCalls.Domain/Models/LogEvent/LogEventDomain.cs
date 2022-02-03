using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Domain.Models.LogEvent
{

  
    public class LogEventDomain:  EntityDataBase
    {
        public int? EventId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
