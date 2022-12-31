using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_逆序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)//单词逆序
        {
            string s = t1.Text;
            if (radioButton1.Checked)
            {
                char[] aa = s.ToCharArray().Reverse().ToArray();
                s = new string(aa);
            }
            else
            {
                string[] bb = s.Split(' ');
                Array.Reverse(bb);
                s = string.Join(" ", bb);
            }
            t2.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.Text = " ";
            t2.Text = " ";
        }
    }
}
