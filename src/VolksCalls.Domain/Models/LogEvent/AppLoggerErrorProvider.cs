using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolksCalls.Domain.Models.LogEvent
{
   public class AppLoggerErrorProvider : ILoggerProvider
    {

        readonly IConfiguration _configuration;
        public ILogger CreateLogger(string categoryName)
        {

            LogLevel[] logsLevel = { LogLevel.Critical, LogLevel.Error };
            return new AppLogger(_configuration, categoryName, (_, logLevel) => logsLevel.Contains(logLevel) );
        }

        public AppLoggerErrorProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {

        }
    }
}
