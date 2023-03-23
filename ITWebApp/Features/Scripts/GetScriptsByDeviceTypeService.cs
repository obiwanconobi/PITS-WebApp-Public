using Infrastructure;
using ITWebApp.Features.GetTicketsByClient;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITWebApp.Features.Scripts
{
    public class GetScriptsByDeviceTypeRequest : IRequest
    {
        public string MachineType { get; set; }
    }

    public class GetScriptsByDeviceTypeService : IAsyncRequestHandler<GetScriptsByDeviceTypeRequest, List<ScriptsDto>>
    {
        private readonly IHttpGet _httpGet;

        public GetScriptsByDeviceTypeService(IHttpGet httpGet) 
        {
            _httpGet = httpGet;
        }
        public async Task<List<ScriptsDto>> HandleAsync(GetScriptsByDeviceTypeRequest request)
        {
            List<ScriptsDto> error = new List<ScriptsDto>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Clear();
            dictionary.Add("machineType", request.MachineType.ToString());
            //Ticket?ticketId={0}
            var route = "Scripts?machineType={0}";

            var cmd = new HttpGetCommand
            {
                Route = route,
                Claims = dictionary
            };
            var response = await _httpGet.Get(cmd);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                List<ScriptsDto> result = JsonConvert.DeserializeObject<List<ScriptsDto>>(responseStream);
                return result;
            }


            return error;
        }
    }
}
