using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api
{
    public class ApiResponse
    {
        
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Content { get; set; }
    }
}
