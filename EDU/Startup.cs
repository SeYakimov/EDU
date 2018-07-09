using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EDU.Startup))]
namespace EDU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
