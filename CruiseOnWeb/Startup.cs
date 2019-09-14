using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CruiseOnWeb.Startup))]
namespace CruiseOnWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
