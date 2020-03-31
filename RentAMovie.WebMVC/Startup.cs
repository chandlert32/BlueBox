using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentAMovie.WebMVC.Startup))]
namespace RentAMovie.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
