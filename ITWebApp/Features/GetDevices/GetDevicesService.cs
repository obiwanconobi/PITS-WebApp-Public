using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Infrastructure;
using ITWebApp.SharedProject;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;

namespace ITWebApp.Features.GetDevices
{
    public class GetDeviceRequestDto : IRequest
    {

    }

    public class GetDevicesService : IAsyncRequestHandler<GetDeviceRequestDto, List<GetDevicesResponseDto>>
    {
        private readonly IHttpGet _get;
        public GetDevicesService(IHttpGet get)
        {
            _get = get;
        }

        public async Task<List<GetDevicesResponseDto>> HandleAsync(GetDeviceRequestDto request)
        {

            HttpGetCommand cmd = new HttpGetCommand();
            cmd.Route = "FullDeviceLog/GetAllDevices";
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
