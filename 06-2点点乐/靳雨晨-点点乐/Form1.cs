using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_点点乐
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;//确定
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;//取消
        }
    }
}
