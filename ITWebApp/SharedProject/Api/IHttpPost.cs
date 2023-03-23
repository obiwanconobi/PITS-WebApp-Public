using ITWebApp.SharedProject.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api.Implementation
{
    public interface IHttpPost
    {
        Task<HttpResponseMessage> Post(HttpPostCommand httpPostCommand);
    }
}
