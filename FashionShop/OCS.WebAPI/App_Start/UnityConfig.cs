using Microsoft.Practices.Unity;
using OCS.BusinessLayer.Services;
using OCS.DataAccess.Repositories;
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

            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductServices, ProductServices>();
            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<IBrandServices, BrandServices>();
            container.RegisterType<IShoppingCartServices, ShoppingCartServices>();
            //RegisterComponents();

            container.RegisterType<IBrandRepository, BrandRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IShoppingCartRepository, ShoppingCartRepository>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}