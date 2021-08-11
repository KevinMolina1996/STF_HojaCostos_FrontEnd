using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AppWebHojaCosto.Startup))]

namespace AppWebHojaCosto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
