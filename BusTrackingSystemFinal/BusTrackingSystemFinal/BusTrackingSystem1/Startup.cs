using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusTrackingSystem1.Startup))]
namespace BusTrackingSystem1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
