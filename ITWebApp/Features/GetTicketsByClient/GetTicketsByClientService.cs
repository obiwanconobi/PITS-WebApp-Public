using Infrastructure;
using ITWebApp.Features.GetTicketsByClient;
using ITWebApp.SharedProject;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetTicketsByClient
{
    public class GetTicketsByClientRequest : IRequest
    {
        public Guid ClientId {get;set;}
    }

    public class GetTicketsByClientService : IAsyncRequestHandler<GetTicketsByClientRequest, List<GetTicketsByClientResponseDto>>
    {

        private readonly IHttpGet _httpGet;
        public GetTicketsByClientService(IHttpGet httpGet)
        {
            _httpGet = httpGet;
        }

        public async Task<List<GetTicketsByClientResponseDto>> HandleAsync(GetTicketsByClientRequest request)
        {
          
            List<GetTicketsByClientResponseDto> error = new List<GetTicketsByClientResponseDto>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Clear();
            dictionary.Add("clientId", request.ClientId.ToString());
            var route = "Ticket/{0}";

            var cmd = new HttpGetCommand
            {
                Route = route,
                Claims = dictionary
            };
            var response = await _httpGet.Get(cmd);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                List<GetTicketsByClientResponseDto> result = JsonConvert.DeserializeObject<List<GetTicketsByClientResponseDto>>(responseStream);
                return result;
            }


            return error;
        }
    
      
      
    }
    
}
