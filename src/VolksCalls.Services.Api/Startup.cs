using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Domain.Models.LogEvent;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting.Ioc;
using VolksCalls.Services.Api.Configuration;

namespace VolksCalls.Services.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        readonly IHostEnvironment _hostEnvironment;

        public Startup(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapperConfiguration();

            services.AddApiConfig(Configuration);

            // services.AddSql(Configuration);
            services.AddMysql(Configuration);

            /*usuarios authenticados rede*/
            services.AddIISConfig(Configuration);

            NativeInjectorBootStrapper.RegisterServices(services, Configuration, _hostEnvironment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddProvider(new AppLoggerProvider(Configuration));
                app.UseCors("Development");
            }
            else if (env.IsProduction())
            {
                //
                loggerFactory.AddProvider(new AppLoggerErrorProvider(Configuration));
                app.UseCors("Production");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
