using AutoMapper;
using BlnckProyect.Infrastructure.Automapper;
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
            container.RegisterInstance<IMapper>(MapperConfig.Mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}