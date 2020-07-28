using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgroPack.Startup))]
namespace AgroPack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
