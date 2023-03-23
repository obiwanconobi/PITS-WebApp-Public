using Infrastructure;
using ITWebApp.SharedProject.Api.Commands;
using ITWebApp.SharedProject.Api.Implementation;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITWebApp.Features.Scripts
{

    public class AddNewScriptService : IAsyncCommandHandler<NewScriptDto>
    {
        private readonly IHttpPost _httpPost;
        public AddNewScriptService(IHttpPost httpPost)
        {

            _httpPost= httpPost;
        }

        public async Task HandleAsync(NewScriptDto command)
        {
            var jsonContent = JsonConvert.SerializeObject(command);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpPostCommand postCommand = new HttpPostCommand
            {
                Route = "Scripts",
                Content = content
            };
            //var result = await _httpPut.Put(postCommand);
            var response = await _httpPost.Post(postCommand);

            
        }
    }
}
