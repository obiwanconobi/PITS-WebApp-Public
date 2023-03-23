using Infrastructure;
using ITWebApp.Features.GetTicketsByClient;
using ITWebApp.Features.GetUsers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITWebApp.Controllers
{
    public class UserController
    {
        private readonly IAsyncRequestHandler<GetUsersByClientRequest, List<GetUserInformationResponseDto>> _getUsersService;

        public UserController(IAsyncRequestHandler<GetUsersByClientRequest, List<GetUserInformationResponseDto>> getUsersService) 
        {
            _getUsersService = getUsersService;
        }
        public async Task<List<GetUserInformationResponseDto>> GetUsersByClientId(Guid clientId)
        {
            var result = await _getUsersService.HandleAsync(new GetUsersByClientRequest { ClientId = clientId });
            return result;

        }
    }
}
