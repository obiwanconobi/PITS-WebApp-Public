using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.Shared.Models
{
    public class FullTicketContent
    {

        public Guid TicketId { get; set; }
        public bool ShowModal { get; set; } = false;
    }
}
