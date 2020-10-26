using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlnckProyect.Infrastructure.Automapper
{
    public class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        public static void RegisterProfiles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // add profiles here
                //cfg.AddProfile<FooProfile>();
            });
            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }
    }
}