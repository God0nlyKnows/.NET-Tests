using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtddSampleWeb.Startup))]
namespace AtddSampleWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
