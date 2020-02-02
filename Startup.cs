using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SouthgateMobileVillage.Startup))]
namespace SouthgateMobileVillage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
