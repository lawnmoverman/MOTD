using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Motd.Web.Startup))]
namespace Motd.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
