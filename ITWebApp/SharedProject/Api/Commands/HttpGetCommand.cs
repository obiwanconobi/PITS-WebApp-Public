using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.SharedProject.Api.Commands
{
    public class HttpGetCommand
    {
        public string Route { get; set; }
        public string CorrelationId { get; set; }
        public string Secret { get; set; }
        public Dictionary<string, string> Claims { get; set; }

    }
}
