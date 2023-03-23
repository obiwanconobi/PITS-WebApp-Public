using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Features.GetFullTicketContent
{
    public class TicketContentDto
    {
        public Guid ContentID { get; set; }
        public Guid ContentTicketID { get; set; }
        public string UpdateByType { get; set; }
		public Guid ContentUpdatedBy { get; set; }
        public DateTime ContentDate { get; set; }
        public string ContentInformation { get; set; }
        public int TimeTracked { get; set; }

    }
}
