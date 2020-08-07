using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FanclubJuventus.Startup))]
namespace FanclubJuventus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
