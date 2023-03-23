using Infrastructure;
using ITWebApp.Features.GetDevices;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetInstalledApps
{

    public class GetInstalledAppsRequestDto : IRequest
    {
        public Guid MachineKey { get; set; }
    }

    public class GetInstalledAppsByDevice : IAsyncRequestHandler<GetInstalledAppsRequestDto, List<InstalledAppsResponseDto>>
    {
        private readonly IHttpGet _get;

        public GetInstalledAppsByDevice(IHttpGet get)
        {
            _get = get;
        }
        public async Task<List<InstalledAppsResponseDto>> HandleAsync(GetInstalledAppsRequestDto request)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //These need to be added in order that they'll be used in the route
            // var dictionary = new Dictionary<string, string>();
            dictionary.Add("machineId", request.MachineKey.ToString());
           

            HttpGetCommand cmd = new HttpGetCommand
            {
                Route = "FullDeviceLog/GetInstalledApps?MachineGuid={0}",
                Claims = dictionary

            };
            var response = await _get.Get(cmd);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = response.Content;
                List<InstalledAppsResponseDto> result = JsonConvert.DeserializeObject<List<InstalledAppsResponseDto>>(responseStream);
                return result;
            }

            return new List<InstalledAppsResponseDto>();
        }
    }
}
   


   