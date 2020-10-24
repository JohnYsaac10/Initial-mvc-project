using AutoMapper;
using BlnckProyect.Infrastructure.Automapper;
using BlnckProyect.Infrastructure.JsonConfig;
using Calabonga.Configurations;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BlnckProyect
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICacheService, CacheService>();
            container.RegisterType<IConfigSerializer, JsonConfigSerializer>();
            container.RegisterType<ApplicationSettings>();
            container.RegisterInstance<IMapper>(MapperConfig.Mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}