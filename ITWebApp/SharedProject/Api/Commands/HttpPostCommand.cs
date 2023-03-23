using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api.Commands
{
    public class HttpPostCommand
    {
		public string Route { get; set; }
		public string CorrelationId { get; set; }
		public string Secret { get; set; }
        public HttpContent Content { get; set; }

    }
}
