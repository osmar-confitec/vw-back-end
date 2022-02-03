using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolksCalls.Application.AutoMapper;

namespace VolksCalls.Services.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), 
                                   typeof(ViewModelToDomainMappingProfile), 
                                   typeof(DomainToDtoMappingProfile),
                                   typeof(InfraToResponseMappingProfile),
                                   typeof(RequestToInfraMappingProfile)

                                   );
        }
    }
}
