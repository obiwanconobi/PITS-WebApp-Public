using ITWebApp.SharedProject.Api.Commands;
using ITWebApp.SharedProject.Api;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using ITWebApp.SharedProject.Api.Implementation;

namespace ITWebApp.Features.Scripts
{
    public class UpdateScriptToRunService : IAsyncCommandHandler<UpdateScriptToRunDto>
    {
        private readonly IHttpPost _httpPut;

        public UpdateScriptToRunService(IHttpPost httpPut)
        {
            _httpPut = httpPut;
        }

     

        public async Task HandleAsync(UpdateScriptToRunDto command)
        {
            var jsonContent = JsonConvert.SerializeObject(command);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpPostCommand postCommand = new HttpPostCommand
            {
                Route = "Scripts/ScriptsToRun",
                Content = content
            };
            //var result = await _httpPut.Put(postCommand);
            using (HttpResponseMessage response = await _httpPut.Post(postCommand))
            {
                response.EnsureSuccessStatusCode();


            }
        }
    }
}
