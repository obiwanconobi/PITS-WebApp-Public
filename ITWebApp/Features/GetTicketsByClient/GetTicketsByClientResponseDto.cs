using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetTicketsByClient
{
    public class GetTicketsByClientResponseDto
    {

        //public Guid TicketID { get; set; }
        //public int TicketStatus { get; set; }
        //public string ClientName { get; set; }
        //public Guid TicketEngineerID { get; set; }
        //public DateTime TicketLastUpdate { get; set; }
        //public string user_forename { get; set; }
        //public string user_surename { get; set; }

       
            public Guid ticketID { get; set; }
            public int ticketStatus { get; set; }
        public string TicketStatusText { get; set; }
            public Guid ticketEngineerID { get; set; }
            public DateTime ticketLastUpdate { get; set; }
            public Guid ticketClientID { get; set; }
            public Guid ticketUserId { get; set; }
        public string user_forename { get; set; }
        public string user_surname { get; set; }
        public List<TicketContent> ticketContent { get; set; }
 
    }

    public class TicketContent
    {
        public Guid contentID { get; set; }
        public Guid contentTicketID { get; set; }
        public Guid contentUpdatedBy { get; set; }
        public DateTime contentDate { get; set; }
        public string contentInformation { get; set; }
        public int timeTracked { get; set; }
        public int isOriginalValue { get; set; }
        public Guid fkTicketDetailsId { get; set; }
    }
}
