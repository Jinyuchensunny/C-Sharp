using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_会跑的老鼠
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int d = 10;
            if (e.X > p1.Left - d && e.X < p1.Right + d && e.Y > p1.Top - d && e.Y < p1.Bottom + d)
            {
                Random r = new Random();
                p1.Left = r.Next(0, this.Width - p1.Width);
                p1.Top = r.Next(0, this.Height - p1.Height);
            }
        }

        private void p1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("逮到咯！");
        }

        //改进血迹
    }
}
