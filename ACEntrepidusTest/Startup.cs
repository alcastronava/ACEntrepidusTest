using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACEntrepidusTest.Startup))]
namespace ACEntrepidusTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
