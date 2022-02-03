using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.LogEvent;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Infra.Data.Repository
{
    public class LogEventRepository : BaseRepository<LogEventDomain>, ILogEventRepository
    {
        public LogEventRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
