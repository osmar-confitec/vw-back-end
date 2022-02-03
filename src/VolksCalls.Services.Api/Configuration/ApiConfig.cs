using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolksCalls.Infra.CrossCutting.AD;
using VolksCalls.Infra.CrossCutting.Emails;

namespace VolksCalls.Services.Api.Configuration
{
    public static class ApiConfig
    {

        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddHttpContextAccessor();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                   // options.JsonSerializerOptions.IgnoreNullValues = true;
                });
            ;
            services.Configure<EmailCallOpenning>(Configuration.GetSection("EmailCallOpenning"));
            services.Configure<EmailSendEvidences>(Configuration.GetSection("EmailSendEvidences"));
            services.Configure<ActiveDirectoryInfraSettings>(Configuration.GetSection("ActiveDirectoryInfraSettings"));

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            /*
             options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        //.AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

             
             */

            /*
             * 
             * options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

                 options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .WithOrigins(Configuration.GetSection("CorsOrigins").Get<string[]>())
                        .AllowAnyHeader());

             .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
             
             */

            services.AddCors(options =>
            {

                options.AddPolicy("Development",
                      builder =>
                          builder
                          .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true) // allow any origin
                  .AllowCredentials()); // allow credentials

                options.AddPolicy("Production",
                    builder =>
                        builder
                        .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            });
            return services;
        }

    }
}
