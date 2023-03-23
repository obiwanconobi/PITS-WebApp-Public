using ITWebApp.Features.UpdateTicket;
using ITWebApp.SharedProject.Api.Commands;
using ITWebApp.SharedProject.Api;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ITWebApp.SharedProject.Api.Implementation;
using Infrastructure;

namespace ITWebApp.Features.SubmitTicket
{
    public class SubmitTicketService : IAsyncCommandHandler<SubmitTicketDto>
    {
        private readonly IHttpPost _httpPost;
        public SubmitTicketService(IHttpPost httpPost) { _httpPost = httpPost; }
        public async Task HandleAsync(SubmitTicketDto command)
        {
            var jsonContent = JsonConvert.SerializeObject(command);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpPostCommand postCommand = new HttpPostCommand
            {
                Route = "Ticket",
                Content = content
            };
            //var result = await _httpPut.Put(postCommand);
            var response = await _httpPost.Post(postCommand);
        }

    }
}
