using ITWebApp.SharedProject.Api.Commands;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api
{
	public interface IHttpPut
	{
		Task<HttpResponseMessage> Put(HttpPutCommand httpPutCommand);

	}
}
