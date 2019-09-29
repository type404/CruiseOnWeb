using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CruiseWeb.Startup))]
namespace CruiseWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
