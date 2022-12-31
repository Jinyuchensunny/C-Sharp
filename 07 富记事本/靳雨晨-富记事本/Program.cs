using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_富记事本
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)//用来传递文件名
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string s = null;
            if (args.Length > 0)//有参数传入
            {
                s = string.Join(" ", args);//一个空格
                string ex = s.Substring(s.LastIndexOf(".") + 1).ToLower();//扩展名
                if (ex.Equals("rtf") || ex.Equals("txt"))
                    Application.Run(new jyc_Form1(s));
                else//扩展名不合法
                {
                    MessageBox.Show("无法打开指定的文件" + s);
                    Application.Exit();//结束应用程序
                }
            }else
                Application.Run(new jyc_Form1());
        }
    }
}
