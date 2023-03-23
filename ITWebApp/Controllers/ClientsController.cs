using Infrastructure;
using ITWebApp.Features.GetClients;
using ITWebApp.SharedProject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITWebApp.Controllers
{
    public class ClientsController
    {
        private readonly IAsyncRequestHandler<GetClientsServiceRequest, List<GetClientsResponseDto>> _getClientsService;
        public ClientsController(IAsyncRequestHandler<GetClientsServiceRequest, List<GetClientsResponseDto>> getClientsService)
        {
            _getClientsService = getClientsService;
        }
        public async Task<List<GetClientsResponseDto>> GetClients()
        {
            return await _getClientsService.HandleAsync(new GetClientsServiceRequest());
        }
    }
}

