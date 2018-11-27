using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_Demo.Models
{
    public class ServerHub : Hub
    {
        public void SendMsg (string msg)
        {
            //调用所有客户端的sendMsg方法
            Clients.All.sendMessage (DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss") , msg);
        }
    }
}