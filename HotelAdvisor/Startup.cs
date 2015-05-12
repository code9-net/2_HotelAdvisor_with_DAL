using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelAdvisor.Startup))]
namespace HotelAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
