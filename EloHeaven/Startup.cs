using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EloHeaven.Startup))]
namespace EloHeaven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
