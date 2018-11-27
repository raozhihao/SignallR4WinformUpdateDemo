using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ServerFrm
{
    public class MyHub:Hub
    {
        /// <summary>
        /// 在连接上时
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected ()
        {
            ///向服务端写入一些数据
            Program.serverFrm.WriteToInfo ("客户端连接ID:" + Context.ConnectionId);
            return base.OnConnected ();
        }

        public override Task OnReconnected ()
        {
            ///向服务端写入一些数据
            Program.serverFrm.WriteToInfo ("客户端退出ID:" + Context.ConnectionId);
            return base.OnReconnected ();
        }

        public override Task OnDisconnected (bool stopCalled)
        {
            ///向服务端写入一些数据
            Program.serverFrm.WriteToInfo ("客户端退出ID:" + Context.ConnectionId);
            return base.OnDisconnected (stopCalled);
        }

        /// <summary>
        /// 这是给客户来调用的
        /// 当客户端的添加按钮点击后
        /// 就调用此方法
        /// 当在客户端绑定了下面的Update方法后
        /// 会自动去调用Update方法
        /// </summary>
        /// <param name="actionId">操作标识符</param>
        public void Send(string actionId)
        {
            /// 这是给客户端来调用的
            /// 在连接服务器之前就给连接代理绑定这个方法
            /// 在客户端连接上此服务后
            /// 客户端绑定此方法,并且传入一个标识符,本例为 "1"(代表要更新界面上的datagridview
            Clients.All.Update (actionId);
        }
        
    }
}
