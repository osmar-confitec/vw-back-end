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
    public static class SqlConfig
    {

        public static void AddSql(this IServiceCollection services,
                                  IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicationContext>(options =>
                 options.UseSqlServer(connectionString)
                 .EnableSensitiveDataLogging()
                 .UseLazyLoadingProxies()
                 );
        }

    }
}
