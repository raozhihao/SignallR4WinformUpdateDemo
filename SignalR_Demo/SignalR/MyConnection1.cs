using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_Demo.SignalR
{
    public class MyConnection1 : PersistentConnection
    {
        protected override Task OnConnected (IRequest request , string connectionId)
        {
            return Connection.Send (connectionId , "Welcome!");
        }

        protected override Task OnReceived (IRequest request , string connectionId , string data)
        {
            return Connection.Broadcast (data);
        }
    }
}