using ITWebApp.SharedProject.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api
{
    public interface IHttpGet 
    {
        Task<ApiResponse> Get(HttpGetCommand httpGetCommand);


    }
}
