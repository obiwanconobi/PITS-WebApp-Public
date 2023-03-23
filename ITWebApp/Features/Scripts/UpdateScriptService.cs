using Infrastructure;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITWebApp.Features.Scripts
{
    public class UpdateScriptService : IAsyncCommandHandler<ScriptsDto>
    {

        private readonly IHttpPut _httpPut;

        public UpdateScriptService(IHttpPut httpPut)
        {
            _httpPut= httpPut;
        }

        public async Task HandleAsync(ScriptsDto command)
        {
            var jsonContent = JsonConvert.SerializeObject(command);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpPutCommand postCommand = new HttpPutCommand
            {
                Route = "Scripts",
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
