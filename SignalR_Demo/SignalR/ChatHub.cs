using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR_Demo.SignalR
{
    /// <summary>
    /// 创建一个集线器类
    /// HubName ("chat")
    /// 是给ChatHub起的别名,在前台客户端进行调用的
    /// </summary>
    [HubName ("chat")]
    public class ChatHub : Hub
    {
        public ChatHub ()
        {
           
        }

        public void Send (string name , string message)
        {
            //给所有的客户端均发送此方法
            //name => 姓名
            //message => 消息
            Clients.All.broadcastMessage (name , message);
           
        }

        

        public void Get ()
        {
            ////这是由服务器端获取的消息
            //Data d = new Data ();
            //d.CreateDate ();
            while ( true )
            {
                Data d = new Data ();
                //每次取了后将此新的存入缓存中
                d.GetNewPerson ();
                Clients.All.getDateTime (DateTime.Now.ToString ());
            }
           
        }
    }
}