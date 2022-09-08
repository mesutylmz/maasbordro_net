using MaasBordro.DAL.api;
using MaasBordro.DAL.impl;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MaasBordro.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPersonelRepo,PersonelRepo>();
            container.RegisterType<IBordroRepo, BordroRepo>();
            container.RegisterType<IDonemlerRepo, DonemlerRepo>();
            container.RegisterType<IMudurlukRepo, MudurlukRepo>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}