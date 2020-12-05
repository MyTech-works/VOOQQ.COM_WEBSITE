using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VOOQQ_APP.Startup))]
namespace VOOQQ_APP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
