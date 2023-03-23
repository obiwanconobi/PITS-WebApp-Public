using Infrastructure;
using ITWebApp.Features.GetFullTicketContent;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITWebApp.Features.UpdateTicket
{
	public class TicketStatusesRequest : IRequest
	{

	}

    public class GetTicketStatusesService :  IAsyncRequestHandler<TicketStatusesRequest, List<TicketStatusTypesDto>>
    {
		private readonly IHttpGet _get;
		public GetTicketStatusesService(IHttpGet get) 
		{
			_get = get;
		}

		public async Task<List<TicketStatusTypesDto>> HandleAsync(TicketStatusesRequest request)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			//These need to be added in order that they'll be used in the route
			// var dictionary = new Dictionary<string, string>();
			//dictionary.Add("ticketId", request.TicketId.ToString());


			var cmd = new HttpGetCommand
			{
				Route = "Ticket/Status"
			//	Claims = dictionary

			};

			var response = await _get.Get(cmd);
			if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
			{
				var responseStream = response.Content;
				List<TicketStatusTypesDto> result = JsonConvert.DeserializeObject<List<TicketStatusTypesDto>>(responseStream);
				// result.TicketContent.OrderByDescending(x => x.ContentDate);
				return result;
			}


			throw new System.NotImplementedException();
		}
	}
}
