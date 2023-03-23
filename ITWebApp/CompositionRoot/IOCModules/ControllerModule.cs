using ITWebApp.Controllers;
using Infrastructure;
using ITWebApp.Features.GetTicketsByClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ITWebApp.CompositionRoot.IOCModules
{
    public static class ControllerModule
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<DevicesController>();
            services.AddSingleton<ClientsController>();
            services.AddSingleton<TicketsController>();
            services.AddSingleton<ScriptsController>();
            services.AddSingleton<UserController>();
            return services;
        }

    }
}
