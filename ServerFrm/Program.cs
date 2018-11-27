using System;
using System.Windows.Forms;

namespace ServerFrm
{
    static class Program
    {
        /// <summary>
        /// 创建一个静态的对象,方便给服务端调用
        /// </summary>
        internal static ServerFrm serverFrm { get; set; }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            serverFrm = new ServerFrm ();
            Application.Run (serverFrm);
        }
    }
}
