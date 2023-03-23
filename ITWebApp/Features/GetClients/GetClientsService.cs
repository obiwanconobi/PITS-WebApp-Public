using Infrastructure;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetClients
{
    public class GetClientsServiceRequest : IRequest { };
    public class GetClientsService : IAsyncRequestHandler<GetClientsServiceRequest, List<GetClientsResponseDto>>
    {
        private readonly IHttpGet _get;
        public GetClientsService(IHttpGet get)
        {
            _get = get;
        }

        public async Task<List<GetClientsResponseDto>> HandleAsync(GetClientsServiceRequest request)
        {
            var route = "Client";
            var cmd = new HttpGetCommand
            {
                Route = route
            };
            var response = await _get.Get(cmd);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                List<GetClientsResponseDto> result = JsonConvert.DeserializeObject<List<GetClientsResponseDto>>(responseStream);
                return result;
            }

            return new List<GetClientsResponseDto>();
        }
    }
}
