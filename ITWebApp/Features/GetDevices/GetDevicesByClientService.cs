using Infrastructure;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetDevices
{
    public class GetDevicesByClientRequestDto : IRequest
    {
        public Guid ClientId { get; set; }
    }

    public class GetDevicesByClientService : IAsyncRequestHandler<GetDevicesByClientRequestDto, List<GetDevicesResponseDto>>
    {
        private readonly IHttpGet _get;
        public GetDevicesByClientService(IHttpGet get)
        {
            _get = get;
        }

        public async Task<List<GetDevicesResponseDto>> HandleAsync(GetDevicesByClientRequestDto request)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Clear();
            dictionary.Add("clientId", request.ClientId.ToString());

            var route = "FullDeviceLog/GetDevicesByClient?clientId={0}";
            var cmd = new HttpGetCommand
            {
                Route = route,
                Claims = dictionary
            };
            var response = await _get.Get(cmd);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                List<GetDevicesResponseDto> result = JsonConvert.DeserializeObject<List<GetDevicesResponseDto>>(responseStream);
                return result;
            }

            return new List<GetDevicesResponseDto>();
        }
    }
}
