using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolksCalls.Services.Api.Configuration
{
    public static class AuthenticationConfig
    {

        public static IServiceCollection AddIISConfig(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            return services;
        }
    }
}
