using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_图片查看器
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string s = string.Join("", args);//获取图片文件名
                string ex = s.Substring(s.LastIndexOf('.') + 1).ToLower();

                if (ex.Equals("bmp") || ex.Equals("jpg") || ex.Equals("gif") || ex.Equals("png") || ex.Equals("icon"))
                {
                    Application.Run(new Form1(s));
                }
                else
                {
                    MessageBox.Show("无法打开文件" + s);
                    Application.Exit();//退出应用程序
                }
            }
            else
                Application.Run(new Form1());
        }
    }
}
