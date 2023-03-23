using Infrastructure;
using ITWebApp.Features.GetDevices;
using ITWebApp.Features.GetInstalledApps;
using ITWebApp.SharedProject;
using ITWebApp.SharedProject.Api;
using ITWebApp.SharedProject.Api.Commands;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITWebApp.Controllers
{
    public class DevicesController
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private readonly IHttpGet _get;
        private readonly IAsyncRequestHandler<GetDeviceRequestDto, List<GetDevicesResponseDto>> _getDevicesService;
        private readonly IAsyncRequestHandler<GetDeviceLogRequestDto, List<GetDevicesResponseDto>> _getDevicesLogService;
        private readonly IAsyncRequestHandler<GetDevicesByClientRequestDto, List<GetDevicesResponseDto>> _getDevicesByClientService;
        private readonly IAsyncRequestHandler<GetInstalledAppsRequestDto, List<InstalledAppsResponseDto>> _getInstalledAppsService;
        public DevicesController(IHttpGet get, IAsyncRequestHandler<GetDeviceRequestDto, List<GetDevicesResponseDto>> getDevicesService, 
            IAsyncRequestHandler<GetDeviceLogRequestDto, List<GetDevicesResponseDto>> getDevicesLogService,
            IAsyncRequestHandler<GetDevicesByClientRequestDto, List<GetDevicesResponseDto>> getDevicesByClientService,
            IAsyncRequestHandler<GetInstalledAppsRequestDto, List<InstalledAppsResponseDto>> getInstalledAppsService)
        {
            _get = get;
            _getDevicesService = getDevicesService;
            _getDevicesLogService = getDevicesLogService;
            _getDevicesByClientService = getDevicesByClientService;
            _getInstalledAppsService = getInstalledAppsService;
        }

        public async Task<List<GetDevicesResponseDto>> GetDevicesByClient(Guid clientId)
        { 
            return await _getDevicesByClientService.HandleAsync(new GetDevicesByClientRequestDto { ClientId = clientId });
        }

        public async Task<List<GetDevicesResponseDto>> GetFullDeviceLog(Guid MachineKey, Guid ClientId)
        {
            var request = new GetDeviceLogRequestDto
            {
                machineKey = MachineKey,
                clientId = ClientId
            };
            return await _getDevicesLogService.HandleAsync(request);

        }

        public async Task<List<GetDevicesResponseDto>> GetDevices()
        {

            return await _getDevicesService.HandleAsync(new GetDeviceRequestDto());

        }

        public async Task<List<InstalledAppsResponseDto>> GetInstalledApps(Guid machineKey)
        {
            return await _getInstalledAppsService.HandleAsync(new GetInstalledAppsRequestDto { MachineKey = machineKey});
        }

    }
}
