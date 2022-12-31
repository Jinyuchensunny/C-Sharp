using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_考试立方体类
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//清空
        {
            length_in.Text = lb_a.Text = lb_v.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(length_in.Text.Trim());
                Cube c = new Cube(x);
                lb_a.Text = c.getA().ToString();
                lb_v.Text = c.getV().ToString();
            }
            catch
            {
                MessageBox.Show("请正确输入长度值");
                return;
            }
            
        }
    }
}
