using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace while语句_斐波那契_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = 1;
            int temp;
            t1.Text = "1 1";    //输出第一和第二个元素
            while (a + b < 200)
            {
                temp = a + b;
                t1.Text += " " + temp.ToString();
                a = b;
                b = temp;
            }

            /*t1.Text = "1";    //输出第一个元素
            do
            {
                t1.Text += " " + b.ToString();
                temp = a + b;
                a = b;
                b = temp;
            }
            while (b < 200);*/
        }
    }
}
