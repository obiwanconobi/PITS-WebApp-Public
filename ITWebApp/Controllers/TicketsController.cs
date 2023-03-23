using Infrastructure;
using ITWebApp.Features;
using ITWebApp.Features.GetFullTicketContent;
using ITWebApp.Features.GetTicketsByClient;
using ITWebApp.Features.PostTicketContent;
using ITWebApp.Features.SubmitTicket;
using ITWebApp.Features.UpdateTicket;
using ITWebApp.SharedProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITWebApp.Controllers
{
    public class TicketsController
    {
        private readonly IAsyncRequestHandler<GetTicketsByClientRequest, List<GetTicketsByClientResponseDto>> _getTicketsByClientsId;
        private readonly IAsyncRequestHandler<GetFullTicketContentRequest, GetFullTicketContentResponseDto> _getFullTicketContentResponse;
        private readonly IAsyncCommandHandler<TicketsCommandDto> _putTicketContent;
        private readonly IAsyncRequestHandler<TicketStatusesRequest, List<TicketStatusTypesDto>> _getTicketStatuses;
        private readonly IAsyncCommandHandler<UpdateTicketDto> _updateTicketDetails;
        private readonly IAsyncCommandHandler<SubmitTicketDto> _submitTicketService;
        public TicketsController(IAsyncRequestHandler<GetTicketsByClientRequest, List<GetTicketsByClientResponseDto>> getTicketsByClientId,
            IAsyncRequestHandler<GetFullTicketContentRequest, GetFullTicketContentResponseDto> getFullTicketContentResponse,
			IAsyncCommandHandler<TicketsCommandDto> putTicketContent,
			IAsyncRequestHandler<TicketStatusesRequest, List<TicketStatusTypesDto>> getTicketStatuses,
			IAsyncCommandHandler<UpdateTicketDto> updateTicketDetails,
            IAsyncCommandHandler<SubmitTicketDto> submitTicketService)
        {
            _getTicketsByClientsId = getTicketsByClientId;
            _getFullTicketContentResponse = getFullTicketContentResponse;
            _putTicketContent = putTicketContent;   
            _getTicketStatuses= getTicketStatuses;
            _updateTicketDetails = updateTicketDetails;
            _submitTicketService = submitTicketService; 
        }

        public async Task PostNewTicket(SubmitTicketDto content)
        {
            await _submitTicketService.HandleAsync(content);
        }

        public async Task PutTicketContent(TicketsCommandDto content)
        {
             await _putTicketContent.HandleAsync(content);
           // return result;
        }
        public async Task PutTicketDetails(UpdateTicketDto content)
        {
            await _updateTicketDetails.HandleAsync(content);
        }


        public async Task<List<GetTicketsByClientResponseDto>> GetTicketsByClientId(Guid clientId)
        {
            var result = await _getTicketsByClientsId.HandleAsync(new GetTicketsByClientRequest{ ClientId = clientId});
            return result;
       
        }

        public async Task<GetFullTicketContentResponseDto> GetFullTicketContent(Guid ticketId)
        {

            return await _getFullTicketContentResponse.HandleAsync(new GetFullTicketContentRequest {TicketId = ticketId });

        }

        public async Task<List<TicketStatusTypesDto>> GetTicketStatusTypes()
        {
            return await _getTicketStatuses.HandleAsync(new TicketStatusesRequest());
        }

    }
}
