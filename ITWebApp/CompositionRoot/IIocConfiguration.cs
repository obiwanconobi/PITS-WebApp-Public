using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.CompositionRoot
{
    public interface IIocConfiguration<out T>
    {
        T Container { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }
}
