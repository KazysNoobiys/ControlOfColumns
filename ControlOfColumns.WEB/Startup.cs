using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlOfColumns.WEB.Startup))]
namespace ControlOfColumns.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
