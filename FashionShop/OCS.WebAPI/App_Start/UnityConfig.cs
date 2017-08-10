using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using OCS.DataAccess.Repositories;

namespace OCS.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();



            container.RegisterType<IBrandRepository, BrandRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IColorRepository, ColorRepository>();
            container.RegisterType<IGenderRepository, GenderRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}