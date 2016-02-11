using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarageWebbRH.Startup))]
namespace GarageWebbRH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
