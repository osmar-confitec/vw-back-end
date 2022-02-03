using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Infra.Data.Context;

namespace VolksCalls.Services.Api.Configuration
{
    public static class MysqlConfig
    {

        public static void AddMysql(this IServiceCollection services,
       IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicationContext>(options =>
                 options.UseMySql(connectionString, (x) => { x.EnableRetryOnFailure(); })
                 .EnableSensitiveDataLogging()
                 .UseLazyLoadingProxies()
                 );
        }
    }
}
