using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR_Demo
{
    [HubName ("test")]
    public class TestHub : Hub
    {
        
        public void Hello ()
        {
            Clients.All.SayHi ("Hi!~");
        }
    }
}