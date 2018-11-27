using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace ServerFrm
{
    public partial class ServerFrm : Form
    {
        public ServerFrm ()
        {
            InitializeComponent ();
        }

        private IDisposable signalR { get; set; }
        private string serverUrl { get; set; } = System.Configuration.ConfigurationManager.AppSettings["url"];
        private void btnStart_Click (object sender , EventArgs e)
        {
            WriteToInfo ("正在连接中....");
            btnStart.Enabled = false;
            Task.Run (() =>
            {
                ServerStart ();
            });
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        private void ServerStart ()
        {
            try
            {
                //开启服务
                signalR = WebApp.Start (serverUrl);
            }
            catch (  Exception ex )
            {
                //服务失败时的处理
                WriteToInfo ("服务开启失败,原因:" + ex.Message);
                this.Invoke (new Action (() =>
                 {
                     btnStart.Enabled = true;
                 }));
                return;
            }
            //服务成功,继续下一步
            this.Invoke (new Action (() =>
             {
                //启用停止按钮
                btnStop.Enabled = true;
             }));
            WriteToInfo ("服务开启成功 : " + serverUrl);
        }

        /// <summary>
        /// 向服务容器写入信息
        /// </summary>
        /// <param name="msg">信息</param>
        internal void WriteToInfo(string msg)
        {
            if ( richTextBox.InvokeRequired )
            {
                this.Invoke (new Action (() =>
                  {
                      WriteToInfo (msg);
                  }));
                return;
            }
            richTextBox.AppendText (msg+Environment.NewLine);
        }

        private async void btnStop_Click (object sender , EventArgs e)
        {
            if ( signalR!=null )
            {
                //向客户端广播消息
                IHubContext _myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub> ();
                await _myHubContext.Clients.All.SendClose ("服务端已关闭");
                signalR.Dispose ();
                Close ();
             
            }
        }

        private void ServerFrm_FormClosing (object sender , FormClosingEventArgs e)
        {
            
           
        }

     
    }
}
