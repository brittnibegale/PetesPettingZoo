using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetesPettingZoo.Startup))]
namespace PetesPettingZoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
