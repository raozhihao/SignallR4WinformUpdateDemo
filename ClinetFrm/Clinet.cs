using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Model;

namespace ClinetFrm
{
    public partial class Clinet : Form
    {
        /// <summary>
        /// 连接代理对象
        /// </summary>
        private IHubProxy hubProxy { get; set; }
        /// <summary>
        /// 绑定的服务器url
        /// </summary>
        private string ServerURI = System.Configuration.ConfigurationManager.AppSettings["url"];

        /// <summary>
        /// 连接对象
        /// </summary>
        private HubConnection hubConnection { get; set; }

        public Clinet ()
        {
            InitializeComponent ();
        }

        private void Clinet_Load (object sender , EventArgs e)
        {
            InitData ();
            InitHub ();
        }

        private async void InitHub ()
        {
            //创建连接对象
            hubConnection = new HubConnection (ServerURI);
           
            //绑定一个集线器
            hubProxy = hubConnection.CreateHubProxy ("MyHub");
            //接收到服务器的消息事件
            hubConnection.Received += HubConnection_Received;
            hubConnection.TransportConnectTimeout = new TimeSpan (8000);
            //注册服务端的方法,此方法请转至服务端MyHub.cs中查看
            hubProxy.On ("Update" , (a) =>
            {
                //如果接收到的是"1"
                if ( a == "1" )
                {
                    //则更新界面
                    InitData ();
                }
            });
            try
            {
                //开始连接
                await hubConnection.Start ();
            }
            catch ( Exception ex )
            {
                this.Text = "服务器未连接上";
                return;
            }
            this.Text = "服务器已连接上";
        }

        private void HubConnection_Received (string obj)
        {
            this.Invoke (new Action (() =>
             {
                 this.Text = obj;
             }));
            
        }

    

        /// <summary>
        /// 加载或更新datagridview
        /// </summary>
        private void InitData ()
        {
            //获取数据
            DemoEntities demo = new DemoEntities ();
            var list = demo.DemoTable.ToList ();
            this.Invoke (new Action (() =>
             {
                 //绑定数据
                 dataGridView1.DataSource = list;

             }));

        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click (object sender , EventArgs e)
        {
            DemoEntities demo = new DemoEntities ();
            demo.DemoTable.Add (new DemoTable ()
            {
                name = txtName.Text ,
                value = txtVal.Text
            });
            demo.SaveChanges ();

            ///使用代理启动方法,启动的是服务端中的Send方法
            ///而在服务端中Send会调用Update方法
            ///因为我们在程序启动时连接上了服务端
            ///而且绑定了Update方法,所以服务端在接收到Send方法被调用的通知时
            ///会自动去广播所有已经连上服务端的客户端使其调用Update方法
            hubProxy.Invoke ("Send" , "1");
        }

        private void Clinet_FormClosing (object sender , FormClosingEventArgs e)
        {
            if ( hubConnection != null )
            {
                hubConnection.Stop ();
                hubConnection.Dispose ();
                
            }
        }

        private void button1_Click (object sender , EventArgs e)
        {
            InitHub ();
        }
    }
}
