using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityStudy.Startup))]
namespace IdentityStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
