using System;

namespace ITWebApp.Features.SubmitTicket
{
    public class SubmitTicketDto
    {
        public Guid ticketClientID { get; set; }
        public Guid ticketUserId { get; set; }
        public string ticketMessage { get; set; }

    }
}
