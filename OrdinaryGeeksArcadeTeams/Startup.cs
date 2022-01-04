using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrdinaryGeeksArcadeTeams.Startup))]
namespace OrdinaryGeeksArcadeTeams
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
