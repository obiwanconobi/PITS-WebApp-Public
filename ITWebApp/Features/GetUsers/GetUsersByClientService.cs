using Infrastructure;
using ITWebApp.Features.GetFullTicketContent;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetUsers
{
    public class GetUsersByClientRequest : IRequest
    {
        public Guid ClientId { get; set; }
    }

    public class GetUsersByClientService : IAsyncRequestHandler<GetUsersByClientRequest, List<GetUserInformationResponseDto>>
    {
        private readonly IHttpGet _get;
        public GetUsersByClientService(IHttpGet get)
        {
            _get = get;
        }

        public async Task<List<GetUserInformationResponseDto>> HandleAsync(GetUsersByClientRequest request)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //These need to be added in order that they'll be used in the route
            // var dictionary = new Dictionary<string, string>();
            dictionary.Add("clientId", request.ClientId.ToString());


            var cmd = new HttpGetCommand
            {
                Route = "UserData?clientId={0}",
                Claims = dictionary

            };

            var response = await _get.Get(cmd);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                List<GetUserInformationResponseDto> result = JsonConvert.DeserializeObject<List<GetUserInformationResponseDto>>(responseStream);
                // result.TicketContent.OrderByDescending(x => x.ContentDate);
                return result;
            }

            return new List<GetUserInformationResponseDto>();
        }
    }
}
