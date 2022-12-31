using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_点点乐
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            if(new Form1().ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new mainform());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
