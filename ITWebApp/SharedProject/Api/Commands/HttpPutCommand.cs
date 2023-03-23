using System.Net.Http;

namespace ITWebApp.SharedProject.Api.Commands
{
	public class HttpPutCommand 
	{
		public string Route { get; set; }
		public string CorrelationId { get; set; }
		public string Secret { get; set; }
		public HttpContent Content { get; set; }
	}
}
