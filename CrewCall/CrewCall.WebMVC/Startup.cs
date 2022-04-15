using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrewCall.WebMVC.Startup))]
namespace CrewCall.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
