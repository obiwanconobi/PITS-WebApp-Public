using Infrastructure;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetFullTicketContent
{
    public class GetFullTicketContentRequest : IRequest
    {
        public Guid TicketId { get; set; }
    }

    public class GetFullTicketContentService : IAsyncRequestHandler<GetFullTicketContentRequest, GetFullTicketContentResponseDto>
    {
        private readonly IHttpGet _get;
        public GetFullTicketContentService(IHttpGet get)
        {
            _get = get;
        }

        public async Task<GetFullTicketContentResponseDto> HandleAsync(GetFullTicketContentRequest request)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //These need to be added in order that they'll be used in the route
            // var dictionary = new Dictionary<string, string>();
            dictionary.Add("ticketId", request.TicketId.ToString());
           

            var cmd = new HttpGetCommand
            {
                Route =  "Ticket?ticketId={0}",
                Claims = dictionary
                
            };

            var response = await _get.Get(cmd);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                GetFullTicketContentResponseDto result = JsonConvert.DeserializeObject<GetFullTicketContentResponseDto>(responseStream);
               // result.TicketContent.OrderByDescending(x => x.ContentDate);
                return result;
            }

            return new GetFullTicketContentResponseDto();
        }
    }
}
