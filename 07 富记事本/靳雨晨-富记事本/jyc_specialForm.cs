using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_富记事本
{
    public partial class jyc_specialForm : Form
    {
        RichTextBox rtb;
        string ch1 = "◆", ch2 = "∵", ch3 = "①", ch4 = "¤";//每种特殊符号的默认值

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: lbl_specchar.Text = ch1;break;
                case 1: lbl_specchar.Text = ch2; break;
                case 2: lbl_specchar.Text = ch3; break;
                case 3: lbl_specchar.Text = ch4; break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                lbl_specchar.Text = rb.Text;
                switch (tabControl1.SelectedIndex)
                {
                    case 0: ch1 = rb.Text; break;
                    case 1: ch2 = rb.Text; break;
                    case 2: ch3 = rb.Text; break;
                    case 3: ch4 = rb.Text; break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb.SelectedText = lbl_specchar.Text;
        }

        public jyc_specialForm(RichTextBox rh)//修改为带参的构造函数
        {
            InitializeComponent();
            rtb = rh;
        }

        private void jyc_specialForm_Load(object sender, EventArgs e)
        {

        }

        private void jyc_specialForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jyc_global.sp = null;
        }
    }
}
