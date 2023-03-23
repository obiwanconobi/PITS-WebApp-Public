using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetFullTicketContent
{
    public class GetFullTicketContentResponseDto
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
