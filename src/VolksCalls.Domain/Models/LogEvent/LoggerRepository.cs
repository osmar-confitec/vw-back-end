using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.LogEvent;

namespace VolksCalls.Domain.Models.LogEvent
{
   public class LoggerRepository
    {
        readonly IConfiguration _configuration ;

        public LoggerRepository(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        private bool ExecuteNonQuery(string commandStr, List<MySqlParameter> paramList)
        {
            var result = false;
            using (var conn = new MySqlConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection")?.Value))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new MySqlCommand(commandStr, conn))
                {
                    command.Parameters.AddRange(paramList.ToArray());
                    var count = command.ExecuteNonQuery();
                    result = count > 0;
                }
            }
            return result;
        }

        public bool InsertLog(LogEventDomain log)
        {
            var command = $@"INSERT INTO volks.logevent (Active,DateRegister,UserInsertedId,Id,EventID,LogLevel,Message,CreatedTime) VALUES (@Active,@DateRegister,@UserInsertedId,@Id,@EventID, @LogLevel, @Message, @CreatedTime)";
            var paramList = new List<MySqlParameter>
            {
                new MySqlParameter("DateRegister", DateTime.Now),
                   new MySqlParameter("Active", true),
                new MySqlParameter("UserInsertedId", Guid.NewGuid().ToString()),
                new MySqlParameter("Id", Guid.NewGuid().ToString()),
                new MySqlParameter("EventID", log.EventId),
                new MySqlParameter("LogLevel", log.LogLevel),
                new MySqlParameter("Message", log.Message),
                new MySqlParameter("CreatedTime", log.CreatedTime)
            };

            return ExecuteNonQuery(command, paramList);
        }
    }
}
