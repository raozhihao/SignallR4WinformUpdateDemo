using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup (typeof (SignalR_Demo.App_Start.Startup))]

namespace SignalR_Demo.App_Start
{
    public class Startup
    {
        public void Configuration (IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR ();
        }
    }
}
