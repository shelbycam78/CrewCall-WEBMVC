using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BAPapp.WebMVC.Startup))]
namespace BAPapp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
