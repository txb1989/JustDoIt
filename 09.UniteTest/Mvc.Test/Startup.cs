using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc.Test.Startup))]
namespace Mvc.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
