using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiSo.Startup))]
namespace BiSo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
