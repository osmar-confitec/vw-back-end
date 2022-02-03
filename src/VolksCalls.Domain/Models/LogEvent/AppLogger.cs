using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Repository;

namespace VolksCalls.Domain.Models.LogEvent
{
    public class AppLogger : ILogger
    {

        private readonly string _nameCategory;
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly int _messageMaxLength = 4000;
        readonly LoggerRepository _loggerRepository;


        public AppLogger(IConfiguration configuration ,string nameCategory, Func<string, LogLevel, bool> filter)
        {
            _nameCategory = nameCategory;
            _filter = filter;
            _loggerRepository = new LoggerRepository(configuration);
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_nameCategory, logLevel));
        }

        public void Log<TState>(
            
            LogLevel logLevel, 
            EventId eventId,
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            var mensagem = formatter(state, exception);
            if (string.IsNullOrEmpty(mensagem))
            {
                return;
            }

            if (exception != null)
                mensagem += $"\n{exception.ToString()}";

            mensagem = mensagem.Length > _messageMaxLength ? mensagem.Substring(0, _messageMaxLength) : mensagem;
            var eventLog = new LogEventDomain()
            {
                Message = mensagem,
                EventId = eventId.Id,
                LogLevel = logLevel.ToString(),
                CreatedTime = DateTime.UtcNow
            };

            _loggerRepository.InsertLog(eventLog);

        }
    }
}
