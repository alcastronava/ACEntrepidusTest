using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACEntrepidusTest19.Startup))]
namespace ACEntrepidusTest19
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
