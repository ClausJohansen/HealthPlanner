using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthPlanner.Web.Startup))]
namespace HealthPlanner.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
