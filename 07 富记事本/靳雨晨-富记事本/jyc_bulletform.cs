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
    public partial class jyc_bulletform : Form
    {
        RichTextBox rtb = null;
        bool rh_wordwrap; //保存原本rh是否启用了自动换行
        bool have_bullet = false; //当前设置段落是否已经有项目符号


        public jyc_bulletform(RichTextBox rh)
        {
            InitializeComponent();
            rtb = rh;
        }


        //注意顺序跟radionbutton的命名顺序相—致
        string[] bulletlist = new string[] { "●", "▇", "★", "◆", "▲", "▼", "○", "□", "◇", "☆", "△", "▽", "╝", "╚", "╔", "╗", "【", "】" };
        private void btn_bulletform_Load(object sender, EventArgs e)
        {
            rh_wordwrap = rtb.WordWrap;//保存原来的自动换行设置
            if (rtb.Lines.Length == 0) return;

            rtb.WordWrap = false;
            if (rtb.Lines[rtb.GetLineFromCharIndex(rtb.SelectionStart)].Length > 0)
            {
                string s = rtb.Text[rtb.GetFirstCharIndexOfCurrentLine()].ToString();//提取段落首字符
                int index = Array.IndexOf(bulletlist, s);//是否是规定的项目符号
                if (index > -1)//首字母是项目符号
                { //将选中的项目符号设置为当前段落的项目符号
                    label1.Text = s;
                    ((RadioButton)Controls["radioButton" + (index + 1).ToString()]).Checked = true;
                    rtb.SelectionStart = rtb.GetFirstCharIndexOfCurrentLine();
                    rtb.SelectionLength = 1;
                    nud_bulletsize.Value = Convert.ToDecimal(rtb.SelectionFont.Size);
                    button1.BackColor = rtb.SelectionColor;
                    label1.ForeColor = rtb.SelectionColor;
                    have_bullet = true;//已有项目符号
                }
            }
            rtb.WordWrap = rh_wordwrap;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton ra = sender as RadioButton;
            if (ra.Checked) label1.Text = ra.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = (sender as Button).BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).BackColor = cd.Color;
                label1.ForeColor = cd.Color;
            }
        }

        private void nud_bulletsize_ValueChanged(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.Name, float.Parse(nud_bulletsize.Value.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtb.WordWrap = false;
            int index = rtb.GetFirstCharIndexOfCurrentLine();//获取段首字符位置
            rtb.SelectionStart = index;
            if (have_bullet) rtb.SelectionLength = 1;
            else rtb.SelectionLength = 0;
            rtb.SelectedText = label1.Text;
            rtb.SelectionStart = index;
            rtb.SelectionLength = 1;

            rtb.SelectionFont = new Font(label1.Font.Name, float.Parse(nud_bulletsize.Value.ToString()));
            rtb.SelectionColor = button1.BackColor;

            rtb.WordWrap = rh_wordwrap;
            this.Close();
        }
    }
}
