using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Application.Interfaces;
using VolksCalls.Application.Services;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Users;
using VolksCalls.Domain.Repository;
using VolksCalls.Domain.Services;
using VolksCalls.Infra.CrossCutting.AD;
using VolksCalls.Infra.CrossCutting.Emails;
using VolksCalls.Infra.Data.Repository;
using VolksCalls.Infra.Data.Uow;

namespace VolksCalls.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, 
                                                        IConfiguration configuration,
                                                        IHostEnvironment hostEnvironment
                                                        )
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Notificacoes
            services.AddScoped<LNotifications>();
            //Emails
            services.AddTransient<IEMailService, EMailService>();
            //
           
            //ICallsServices
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICallCategoriesListServices, CallCategoriesListServices>();
            services.AddScoped<ICallsServices, CallsServices>();
            services.AddScoped<ICallsApplication, CallsApplication>();

            /*CI*/

            services.AddScoped<ICIRepository, CIRepository>();
            services.AddScoped<ICIServices, CIServices>();
            services.AddScoped<ICIApplication, CIApplication>();
            services.AddScoped<IEvidenceApplication, EvidenceApplication>();

            /*FormService*/
            services.AddScoped<ICallsFormsApplication, CallsFormsApplication>();
            services.AddScoped<ICallsFormsServices, CallsFormsServices>();
            services.AddScoped<ICallsFormsRepository, CallsFormsRepository>();
            services.AddScoped<ICallRepository, CallRepository>();

            //


            /*FormService Questions */
            services.AddScoped<ICallFormQuestionsRepository, CallFormQuestionsRepository>();
            services.AddScoped<ICallFormQuestionsServices, CallFormQuestionsServices>();
            services.AddScoped<ICallFormQuestionsApplication, CallFormQuestionsApplication>();




            if (hostEnvironment.IsDevelopment())
            {
                services.AddScoped<IUsersService, UsersService>();
            }
            else if
                (hostEnvironment.IsProduction())
            {
                services.AddScoped<IUsersService, UsersADService>();
            }

            services.AddScoped<IEvidenceService, EvidenceService>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICallCategoriesListApplication, CallCategoriesListApplication>();

            //IUser
            services.AddScoped<IUser, AspNetUser>();
           // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //CallsCategory
            services.AddScoped<ICallsCategoryRepository, CallsCategoryRepository>();
            services.AddScoped<ICallsCategoryServices, CallsCategoryServices>();
            services.AddScoped<ICallsCategoryApplication, CallsCategoryApplication>();
            services.AddScoped<ILogEventRepository, LogEventRepository>();
            services.AddScoped<ICallsPreferencesRepository, CallsPreferencesRepository>();
            services.AddScoped<ICallCategoriesListRepository, CallCategoriesListRepository>();
            //CallCategoriesListdani
            //
            //

            /**/

            //IActiveDirectoryInfra
            services.AddScoped<IActiveDirectoryInfra, ActiveDirectoryInfra>();

        }
    }
}
