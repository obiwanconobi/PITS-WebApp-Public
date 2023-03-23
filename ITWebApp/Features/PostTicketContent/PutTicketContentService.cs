using Infrastructure;
using ITWebApp.Features.GetFullTicketContent;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using ITWebApp.SharedProject.Api.Implementation;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Text;

namespace ITWebApp.Features.PostTicketContent
{



	public class PutTicketContentService : IAsyncCommandHandler<TicketsCommandDto>
	{
		private readonly IHttpPut _httpPut;
		public PutTicketContentService(IHttpPut httpPut)
		{
			_httpPut = httpPut;
		}

		public async Task HandleAsync(TicketsCommandDto command)
		{

			//JsonConvert.DeserializeObject<GetFullTicketContentResponseDto>(responseStream);
			var jsonContent = JsonConvert.SerializeObject(command);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
			HttpPutCommand postCommand = new HttpPutCommand
			{
				Route = "Ticket",
				Content = content
			};
			//var result = await _httpPut.Put(postCommand);
			using (HttpResponseMessage response = await _httpPut.Put(postCommand))
			{
				response.EnsureSuccessStatusCode();
			
				
			}
		}
	}
}
