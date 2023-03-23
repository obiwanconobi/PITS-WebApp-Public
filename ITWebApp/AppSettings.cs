using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp
{
    public interface IAppSettings
    {
        string ApiBaseUrl { get; }
    }

    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _config;
        public AppSettings(IConfiguration config)
        {
            _config = config;
        }

        public string ApiBaseUrl
        {
            
            get { return _config["ApiBaseUrl"]; }
        }
    }
}
