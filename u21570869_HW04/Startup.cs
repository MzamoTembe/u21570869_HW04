using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(u21570869_HW04.Startup))]

namespace u21570869_HW04
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}