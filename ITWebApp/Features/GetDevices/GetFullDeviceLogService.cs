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
    public class GetDeviceLogRequestDto : IRequest 
    {
        public Guid machineKey { get; set; }
        public Guid clientId { get; set; }
    };
    public class GetFullDeviceLogService : IAsyncRequestHandler<GetDeviceLogRequestDto, List<GetDevicesResponseDto>>
    {
        private readonly IHttpGet _get;
        public GetFullDeviceLogService(IHttpGet get)
        {
            _get = get;
        }

        public async Task<List<GetDevicesResponseDto>> HandleAsync(GetDeviceLogRequestDto request)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //These need to be added in order that they'll be used in the route
            // var dictionary = new Dictionary<string, string>();
            dictionary.Add("machineId", request.machineKey.ToString());
            dictionary.Add("clientId", request.clientId.ToString());

            HttpGetCommand cmd = new HttpGetCommand
            {
                Route = "FullDeviceLog?MachineGuid={0}&ClientId={1}",
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
