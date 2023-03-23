using ITWebApp.Features.GetFullTicketContent;
using System;
using System.Collections.Generic;

namespace ITWebApp.Features.UpdateTicket
{
    public class UpdateTicketDto
    {
        public Guid TicketID { get; set; }
        public int TicketStatus { get; set; }
        public Guid TicketEngineerID { get; set; }
        public DateTime TicketLastUpdate { get; set; }
        public Guid TicketClientID { get; set; }
        public Guid TicketUserId { get; set; }
        public List<TicketContentDto> TicketContent { get; set; }
    }
}
