using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnnaLeaoStore.UI.Startup))]
namespace AnnaLeaoStore.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
