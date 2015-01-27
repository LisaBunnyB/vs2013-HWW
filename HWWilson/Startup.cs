using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWWilson.Startup))]
namespace HWWilson
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
