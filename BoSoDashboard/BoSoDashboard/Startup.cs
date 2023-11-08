using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoSoDashboard.Startup))]
namespace BoSoDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
