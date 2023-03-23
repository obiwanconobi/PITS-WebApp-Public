using Infrastructure;
using System;

namespace ITWebApp.Features.PostTicketContent
{
	public class TicketsCommandDto : ICommand
	{

	
			public Guid contentID { get; set; }
			public Guid contentTicketID { get; set; }
			public string UpdateByType { get; set; }
			public Guid contentUpdatedBy { get; set; }
			public DateTime contentDate { get; set; }
			public string contentInformation { get; set; }
			public int timeTracked { get; set; }
			public int isOriginalValue { get; set; }
			public Guid fkTicketDetailsId { get; set; }
	


	}
}
