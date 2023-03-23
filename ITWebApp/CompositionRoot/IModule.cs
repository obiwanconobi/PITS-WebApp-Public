using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.CompositionRoot
{
    public interface IModule
    {
        void Load(Container container, IConfiguration configuration);
    }
}
