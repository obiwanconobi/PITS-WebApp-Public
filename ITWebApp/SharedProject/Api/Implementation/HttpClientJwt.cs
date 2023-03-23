using ITWebApp.Features.GetDevices;
using ITWebApp.Features.GetFullTicketContent;
using ITWebApp.Features.SubmitTicket;
using ITWebApp.SharedProject.Api.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api.Implementation
{
    public class HttpClientJwt : IHttpGet, IHttpPut, IHttpPost
    {
        private readonly HttpClient _client;
        private readonly HttpStatusCode[] _successStatusCode = { HttpStatusCode.OK, HttpStatusCode.Created };

        public HttpClientJwt(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResponse> Get(HttpGetCommand httpGetCommand)
        {
            string result = null;
            GenerateJwtToken _jwt = new GenerateJwtToken();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwt.Generate());

            var route = httpGetCommand.Route;
            
            var count = 0;
            if(httpGetCommand.Claims != null)
            {
                foreach (var rr in httpGetCommand.Claims)
                {
                    string routes = "{" + count + "}";
                    route = route.Replace(routes, rr.Value);
                    count++;
                }
            }
            try
            {
                result = await _client.GetStringAsync(route);
            }catch(Exception ex)
            {

            }
            

           if(result != null)
            {
                return new ApiResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Content = result
                };
            }

            return new ApiResponse { HttpStatusCode = HttpStatusCode.NotFound };

        }

        public async Task<HttpResponseMessage> Put(HttpPutCommand httpPutCommand)
        {
			
			GenerateJwtToken _jwt = new GenerateJwtToken();
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwt.Generate());
			var route = httpPutCommand.Route;

		
            try
            {
               // var content = new StringContent(httpPutCommand.JsonContent);
                var result = await _client.PutAsync(httpPutCommand.Route, httpPutCommand.Content);
               // HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Put, httpPutCommand.Route);
               // msg.Content = (HttpContent) new ObjectContent<>
               //var result = await _client.SendAsync()
                return result;
			
			}
			catch (Exception ex)
			{

			}

			throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> Post(HttpPostCommand httpPostCommand)
        {

            GenerateJwtToken _jwt = new GenerateJwtToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwt.Generate());
            var route = httpPostCommand.Route;
           // SubmitTicketDto content = JsonConvert.DeserializeObject<SubmitTicketDto>(httpPostCommand.Content);

            try
            {
                // var content = new StringContent(httpPutCommand.JsonContent);
                var result = await _client.PostAsync(httpPostCommand.Route, httpPostCommand.Content);
                // HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Put, httpPutCommand.Route);
                // msg.Content = (HttpContent) new ObjectContent<>
                //var result = await _client.SendAsync()
                return result;

            }
            catch (Exception ex)
            {

            }

            throw new NotImplementedException();
        }

    }
}
