using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.LogEvent;

namespace VolksCalls.Domain.Repository
{
   public interface ILogEventRepository : IBaseRepository<LogEventDomain>
    {
    }
}
