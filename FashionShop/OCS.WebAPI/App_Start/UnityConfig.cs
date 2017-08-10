using Microsoft.Practices.Unity;
using OCS.BusinessLayer.Services;
using OCS.DataAccess.Repositories;
using System.Web.Http;
using Unity.WebApi;

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

            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductServices, ProductServices>();
            //RegisterComponents();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}