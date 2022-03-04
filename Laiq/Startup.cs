using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laiq.Startup))]
namespace Laiq
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
