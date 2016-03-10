using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlphaRenting.Startup))]
namespace AlphaRenting
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
