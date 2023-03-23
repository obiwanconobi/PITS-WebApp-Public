using Infrastructure;
using ITWebApp.Features.GetClients;
using ITWebApp.Features.GetDevices;
using ITWebApp.Features.GetFullTicketContent;
using ITWebApp.Features.GetInstalledApps;
using ITWebApp.Features.GetTicketsByClient;
using ITWebApp.Features.GetUsers;
using ITWebApp.Features.PostTicketContent;
using ITWebApp.Features.Scripts;
using ITWebApp.Features.SubmitTicket;
using ITWebApp.Features.UpdateTicket;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;


namespace ITWebApp.CompositionRoot.IOCModules
{
    public static class HandlerModule
    {
        public static IServiceCollection AddHandlerServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Tickets
            services.AddSingleton<IAsyncRequestHandler<GetTicketsByClientRequest, List<GetTicketsByClientResponseDto>>, GetTicketsByClientService>();
            services.AddSingleton<IAsyncRequestHandler<GetFullTicketContentRequest, GetFullTicketContentResponseDto>, GetFullTicketContentService>();
            services.AddSingleton<IAsyncCommandHandler<TicketsCommandDto>, PutTicketContentService>();
            services.AddSingleton<IAsyncRequestHandler<TicketStatusesRequest, List<TicketStatusTypesDto>>, GetTicketStatusesService>();
            services.AddSingleton<IAsyncCommandHandler<UpdateTicketDto>,UpdateTicketService>();
            services.AddSingleton<IAsyncCommandHandler<SubmitTicketDto>, SubmitTicketService>();

            //Scripts
            services.AddSingleton<IAsyncRequestHandler<GetScriptsByDeviceTypeRequest, List<ScriptsDto>>,GetScriptsByDeviceTypeService>();   
            services.AddSingleton<IAsyncCommandHandler<ScriptsDto>, UpdateScriptService>();
            services.AddSingleton<IAsyncCommandHandler<NewScriptDto>, AddNewScriptService>();
            services.AddSingleton<IAsyncCommandHandler<UpdateScriptToRunDto>, UpdateScriptToRunService>();

            //Devices
            services.AddSingleton<IAsyncRequestHandler<GetDevicesByClientRequestDto, List<GetDevicesResponseDto>>, GetDevicesByClientService>();
            services.AddSingleton<IAsyncRequestHandler<GetDeviceRequestDto, List<GetDevicesResponseDto>>, GetDevicesService>();
            services.AddSingleton<IAsyncRequestHandler<GetDeviceLogRequestDto, List<GetDevicesResponseDto>>, GetFullDeviceLogService>();
            services.AddSingleton<IAsyncRequestHandler<GetInstalledAppsRequestDto, List<InstalledAppsResponseDto>>, GetInstalledAppsByDevice>();

            //Clients
            services.AddSingleton<IAsyncRequestHandler<GetClientsServiceRequest, List<GetClientsResponseDto>>, GetClientsService>();

            //Users
            services.AddSingleton<IAsyncRequestHandler<GetUsersByClientRequest, List<GetUserInformationResponseDto>>, GetUsersByClientService>();
          
            services.AddHttpClient<IHttpGet, HttpClientJwt>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new System.Uri(configuration.GetSection("ApiBaseUrl").Value);
                c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            });
			services.AddHttpClient<IHttpPut, HttpClientJwt>().ConfigureHttpClient(c =>
			{
				c.BaseAddress = new System.Uri(configuration.GetSection("ApiBaseUrl").Value);
				c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			});
            services.AddHttpClient<IHttpPost, HttpClientJwt>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new System.Uri(configuration.GetSection("ApiBaseUrl").Value);
                c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            });
            return services;
        }
    }
}
