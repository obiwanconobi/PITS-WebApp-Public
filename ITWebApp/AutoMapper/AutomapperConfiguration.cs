using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWebApp.AutoMapper
{
    public class AutomapperConfiguration
    {
        public static MapperConfiguration Configuration { get; set; }

        public static IMapper CreateMapper()
        {
            return Configuration.CreateMapper();
        }

        static AutomapperConfiguration()
        {
            Configuration = CreateAutoMapperConfiguration();
        }

        public static MapperConfiguration CreateAutoMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
        }


    }
}
