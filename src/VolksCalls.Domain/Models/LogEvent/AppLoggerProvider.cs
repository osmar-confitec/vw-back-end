using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Domain.Models.LogEvent
{
    public class AppLoggerProvider : ILoggerProvider
    {

        readonly IConfiguration _configuration; 
        public ILogger CreateLogger(string categoryName)
        {
            return new AppLogger(_configuration, categoryName, (_, logLevel) => logLevel >= LogLevel.Information);
        }

        public AppLoggerProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {
            
        }
    }
}
