using Challenge1.Services.Implementation;
using Challenge1.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge1.UI.Configuration
{
    public class ConfigureDependecies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ILocationService, LocationService>();


        }
    }
}
