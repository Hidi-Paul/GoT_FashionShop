using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OCS.MVC.Startup))]
namespace OCS.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
