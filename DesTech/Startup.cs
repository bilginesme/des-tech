using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DesTech.Startup))]
namespace DesTech
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
