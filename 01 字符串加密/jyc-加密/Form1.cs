using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_加密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //提取原文
            string s = textBox1.Text;
            //转换成字符数组
            char[] cc = s.ToCharArray();
            //加密处理
            for(int i = 0; i < cc.Length; i++)
            {
                if (char.IsDigit(cc[i]))
                    cc[i] = (char)(cc[i] + 2 > '9' ? cc[i] + 2 - 10:cc[i] + 2);
                else
                {
                    if (char.IsLower(s[i]))//小写字母
                        cc[i] = char.ToUpper((char)(cc[i] + 3 > 'z' ? cc[i] + 3 - 26 : cc[i] + 3));
                    else
                    {
                        if (char.IsUpper(s[i]))//大写字母
                            cc[i] = char.ToLower((char)(cc[i] + 3 > 'Z' ? cc[i] + 3 - 26 : cc[i] + 3));
                    }
                }
            }
            //输出
            s = new string(cc);
            textBox2.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)//字符串解密，结果不正确
        {
            //提取原文
            string s = textBox2.Text;
            //转换成字符数组
            char[] cc = s.ToCharArray();
            //加密处理
            for (int i = 0; i < cc.Length; i++)
            {
                if (char.IsDigit(cc[i]))
                    cc[i] = (char)(cc[i] - 2 > '9' ? cc[i] - 2 - 10 : cc[i] - 2);
                else
                {
                    if (char.IsLower(s[i]))//小写字母
                        cc[i] = char.ToUpper((char)(cc[i] - 3 > 'z' ? cc[i] - 3 - 26 : cc[i] - 3));
                    else
                    {
                        if (char.IsUpper(s[i]))//大写字母
                            cc[i] = char.ToLower((char)(cc[i] - 3 > 'Z' ? cc[i] - 3 - 26 : cc[i] - 3));
                    }
                }
            }
            //输出
            s = new string(cc);
            textBox1.Text = s;
        }
    }
}
